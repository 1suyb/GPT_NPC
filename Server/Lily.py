class NPC :
    def __init__(self,name,profile) :
        self.state = "집에 가고 있습니다."
        self.profile = profile
        self.actions = " JoyfulJump, Dancing, Greeting, Angry, Anything"
        self.messages = []
        self.name = name

    def Action(self,name,message,response) :
        action = [
            {"role" : "user", "content" : self.profile},
            {"role" : "user", "content" : self.name+"의 현재상황 : "+ self.state},
            {"role" : "user", "content" : name+" : " + message},
            {"role" : "user", "content" : self.name+" : " + response},
            {"role" : "user", "content" : self.name+"가 선택가능한 Action : " + self.actions},
            {"role" : "user", "content" : self.name + "가 취할 Action : "}
        ]
        for ac in action :
            print(ac["content"])
        return action
    
    def Response_(self,name,message) :
        response = [
            {"role" : "user", "content" : self.profile},
            {"role" : "user", "content" : self.name+"의 현재상황 : "+ self.state},
            {"role" : "user", "content" : name+" : " + message},
            {"role" : "user", "content" : self.name+"의 응답을 작성하세요."},
        ]
        for ac in response :
            print(ac["content"])
        return response
    
    def State(self,name,message,response) : 
        state = [
            {"role" : "user", "content" : self.profile},
            {"role" : "user", "content" : self.name+"의 현재상황 : "+ self.state},
            {"role" : "user", "content" : name+" : " + message},
            {"role" : "user", "content" : self.name+" : " + response},
            {"role" : "user", "content" : "현재 상황을 정리해줘"},
        ]
        for ac in state :
             print(ac["content"])
        return state
    
    def setState(self, state) : 
        self.state = state