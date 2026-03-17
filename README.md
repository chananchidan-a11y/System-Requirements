          ┌────────────────────┐
          │      Person        │  <<abstract>>
          ├────────────────────┤
          │ - Name : string    │
          │ - StudentID : string │
          ├────────────────────┤
          │ + Person()         │
          └─────────▲──────────┘
                    │ (inherit)
          ┌─────────┴──────────┐
          │      Student       │
          ├────────────────────┤
          │ - score : int      │
          ├────────────────────┤
          │ + Score { get; set } │
          │ + GetGrade() : string │
          └─────────▲──────────┘
                    │ (has many)
          ┌─────────┴──────────┐
          │      Course        │
          ├────────────────────┤
          │ - CourseName : string │
          │ - CourseID : string   │
          │ - students : List<Student> │
          ├────────────────────┤
          │ + AddStudent()     │
          │ + ShowAll()        │
          │ + ShowMaxMin()     │
          │ + ShowFail()       │
          │ + ShowAverage()    │
          └─────────▲──────────┘
                    │
          ┌─────────┴──────────┐
          │      Program       │
          ├────────────────────┤
          │ + Main()           │
          └────────────────────┘
