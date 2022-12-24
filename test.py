import random
import string
from typing import Optional
import httpx
from pydantic import BaseModel
from time import perf_counter

URL = "https://localhost:7263"


class App(BaseModel):
    processId: Optional[int]
    name: Optional[str]
    path: Optional[str]
    isRunning: Optional[bool]


class FlaUIClient:
    def __init__(self, url) -> None:
        self.url = url

    def launch(self, path):
        data = App(path=path)
        data = data.dict(exclude_none=True)
        response = httpx.post(f"{self.url}/app", json=data, verify=False)
        return App(**response.json())

    # def type(self, auto_id, text):
    #     by = By(automation_id=auto_id)
    #     type_req = TypeRequest(by=by, text=text)

    # def click(self, by):
    #     return self._stub.Click(by)

    # def click_by_coordinates(self, x, y):
    #     coords = Coordinates(x=x, y=y)
    #     return self._stub.ClickCoords(coords)
    
    # def get_screenshot(self, filepath):
    #     file = self._stub.Screenshot(Empty())
    #     with open(filepath, 'wb') as f:
    #         f.write(file.buffer)


app_path = "C:\\Users\\almos\\VSCodeProjects\\flaui-http\\WpfApplication.exe"
# app_path = "notepad.exe"

client = FlaUIClient(URL)

response = client.launch(app_path)
print(response)

s = ''.join([random.choice(string.ascii_letters) for _ in range(100)])
# client.type("TextBox", s)

# client.click_by_coordinates(200, 250)
# client.click(By(name="ContextMenu"))

# client.get_screenshot('test_client_screenshot.jpg')
