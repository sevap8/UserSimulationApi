# UserSimulationApi

POST - PM:  Invoke-RestMethod https://localhost:44301/api/User -Method POST -Body (@{Id= 1; Name= "SomeName"; Surname= "SomeSurname"} | ConvertTo-Json) -ContentType "application/json"

GET - api/User/5

PUT - Invoke-RestMethod https://localhost:44301/api/User/1 -Method PUT -Body (@{Id= 4; Name= "SomeNasme"; Surname= "SomeSurnasme"} | ConvertTo-Json) -ContentType "application/json"
