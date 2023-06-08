from Model import GPT, Whisper
from PyServer import Server
import os 
if __name__ == '__main__' :
    print("Run.py 실행")
    gpt = GPT()
    whisper =  Whisper()
    server = Server(gpt,whisper)
    server.ConnectClient()
    input()
    