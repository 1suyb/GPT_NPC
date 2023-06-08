import openai
from transformers import WhisperProcessor, WhisperForConditionalGeneration
import numpy as np
import os
from Lily import NPC


class GPT : 
    def __init__(self,api_key = "") :
        openai.api_key = "APIKEY"
        self.NPC = NPC("릴리", "릴리의 프로필 \n \
     릴리의 성격 : 릴리는 호기심이 많고 지식을 탐구하는 것을 좋아합니다. \
     새로운 사물이나 아이디어에 대해 열린 마음을 갖고,\
     지속적인 학습과 개발에 관심을 가지며 새로운 경험을 즐깁니다.\
     그녀는 끊임없이 자기계발을 추구하고 새로운 것을 베우는 것에 흥미를 느낍니다.\
     하지만 바보라는말에 쉽게 화를 냅니다.\
     릴리는 지금 신이나있는 상태입니다.")
     
    def Response(self,msg) :
        completion = openai.ChatCompletion.create(
            model='gpt-3.5-turbo',
            messages=msg
        )
        response = completion.choices[0].message['content']
        print(response)
        return response
    
    def Action(self,msg) :
        completion = openai.ChatCompletion.create(
            model='gpt-3.5-turbo',
            messages=msg,
            temperature=0
        )
        response = completion.choices[0].message['content']
        print(response)
        return response
    
    def __call__(self,name,msg) :
        response = self.Response(self.NPC.Response_(name,msg))
        action = self.Action(self.NPC.Action(name,msg,response))
        state = self.Response(self.NPC.State(name,msg,response))
        self.NPC.setState(state)
        return response, action

class Whisper : 
    def __init__(self, 
                 processor_check_point="openai/whisper-base", 
                 model_check_point="/Whisper/checkpoint-4176") : 
        self.processor = WhisperProcessor.from_pretrained(processor_check_point)
        self.model = WhisperForConditionalGeneration.from_pretrained(model_check_point)
        self.forced_decoder_ids = self.processor.get_decoder_prompt_ids(language="korean", task="transcribe")
    
    def Transcribe(self,wave) :
        npwave = np.array(wave)
        input_feature = self.processor(npwave, sampling_rate=16000, return_tensors='pt').input_features
        predicted_ids = self.model.generate(input_feature, forced_decoder_ids=self.forced_decoder_ids)
        transcription = self.processor.batch_decode(predicted_ids, skip_special_tokens=True)
        return transcription
    
    def __call__(self, wave):
        transcription = ""
        transcription = self.Transcribe(wave)[0]
        return transcription
