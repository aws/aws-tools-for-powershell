Describe -Tag "Smoke" "AWS.PowerTools.DynamoDB ConvertTo-DDBItem Unit Tests" {
    $testCases = @(
        @{
            InputObject = @{
                TestProperty = 'kingarthur'
            }
            DdbType = 'S'
            PSType = 'String'
            DdbSubType = $null
        },
        @{
            InputObject = @{
                TestProperty = [System.Collections.Generic.HashSet[String]]@('king', 'arthur')
            }
            DdbType = 'SS'
            PSType = 'HashSet`1'
            DdbSubType = $null
        },
        @{
            InputObject = @{
                TestProperty = $true
            }
            DdbType = 'BOOL'
            PSType = 'Bool'
            DdbSubType = $null
        },
        @{
            InputObject = @{
                TestProperty = [Double]1
            }
            DdbType = 'N'
            PSType = 'Double'
            DdbSubType = $null
        },
        @{
            InputObject = @{
                TestProperty = [Long]1
            }
            DdbType = 'N'
            PSType = 'Long'
            DdbSubType = $null
        },
        @{
            InputObject = @{
                TestProperty = [Int16]1
            }
            DdbType = 'N'
            PSType = 'Int16'
            DdbSubType = $null
        },
        @{
            InputObject = @{
                TestProperty = [UInt16]1
            }
            DdbType = 'N'
            PSType = 'UInt16'
            DdbSubType = $null
        },
        @{
            InputObject = @{
                TestProperty = [Int32]1
            }
            DdbType = 'N'
            PSType = 'Int32'
            DdbSubType = $null
        },
        @{
            InputObject = @{
                TestProperty = [UInt32]1
            }
            DdbType = 'N'
            PSType = 'UInt32'
            DdbSubType = $null
        },
        @{
            InputObject = @{
                TestProperty = [Int64]1
            }
            DdbType = 'N'
            PSType = 'Int64'
            DdbSubType = $null
        },
        @{
            InputObject = @{
                TestProperty = [UInt64]1
            }
            DdbType = 'N'
            PSType = 'UInt64'
            DdbSubType = $null
        },
        @{
            InputObject = @{
                TestProperty = [System.Collections.Generic.HashSet[Int]]@(1,2,3)
            }
            DdbType = 'NS'
            PSType = 'HashSet`1'
            DdbSubType = $null
        },
        @{
            InputObject = @{
                TestProperty = ([IO.MemoryStream]::new([Text.Encoding]::UTF8.GetBytes('king')))
            }
            DdbType = 'B'
            PSType = 'System.IO.MemoryStream'
            DdbSubType = $null
        },
        @{
            InputObject = @{
                TestProperty = [System.Collections.Generic.HashSet[System.IO.MemoryStream]]@(([IO.MemoryStream]::new([Text.Encoding]::UTF8.GetBytes('king'))),([IO.MemoryStream]::new([Text.Encoding]::UTF8.GetBytes('king'))))
            }
            DdbType = 'BS'
            PSType = 'HashSet`1'
            DdbSubType = $null
        },
        @{
            InputObject = @{
                TestProperty = $null
            }
            DdbType = 'NULL'
            PSType = 'NULL'
            DdbSubType = $null
        },
        @{
            InputObject = @{
                TestProperty = @{
                    UserId = 'arthurjr'
                }
            }
            DdbType = 'M'
            PSType = 'Hashtable'
            DdbSubType = $null
        },
        @{
            InputObject = @{
                TestProperty = @('king', 'arthur')
            }
            DdbType = 'L'
            PSType = 'Object[]'
            DdbSubType = 'S'
        },
        @{
            InputObject = @{
                TestProperty = @(1, 2)
            }
            DdbType = 'L'
            PSType = 'Object[]'
            DdbSubType = 'N'
        },
        @{
            InputObject = @{
                TestProperty = [System.Collections.Generic.List[String]]@('king', 'arthur')
            }
            DdbType = 'L'
            PSType = 'List`1'
            DdbSubType = 'S'
        },
        @{
            InputObject = @{
                TestProperty = [System.Collections.Generic.List[Int32]]@(1, 2)
            }
            DdbType = 'L'
            PSType = 'List`1'
            DdbSubType = 'N'
        },
        @{
            InputObject = @{
                TestProperty = [System.Collections.Generic.List[Boolean]]@($true, $false)
            }
            DdbType = 'L'
            PSType = 'List`1'
            DdbSubType = 'BOOL'
        },
        @{
            InputObject = @{
                TestProperty = [System.Collections.Generic.List[System.IO.MemoryStream]]@(([IO.MemoryStream]::new([Text.Encoding]::UTF8.GetBytes('king'))),([IO.MemoryStream]::new([Text.Encoding]::UTF8.GetBytes('king'))))
            }
            DdbType = 'L'
            PSType = 'List`1'
            DdbSubType = 'B'
        },
        @{
            InputObject = @{
                TestProperty = [System.Collections.ArrayList]@('king', 'arthur')
            }
            DdbType = 'L'
            PSType = 'ArrayList'
            DdbSubType = 'S'
        }
        @{
            InputObject = @{
                TestProperty = [System.Collections.ArrayList]@(1.1, 2.2)
            }
            DdbType = 'L'
            PSType = 'ArrayList'
            DdbSubType = 'N'
        }
    )
    It "ConvertTo-DDBItem converts a hashtable with an entry of PSType '<PSType>' to a hashtable containing the DDBattribute '<DdbType>'" -TestCases $testCases {
        param ($InputObject, $DdbType, $DdbSubType)
        $result = ConvertTo-DDBItem -InputObject $InputObject

        # The map datatype requires a different comparison than the other datatypes.
        if ($DdbType -eq 'M')
        {
            $result.TestProperty.$DdbType.Value | Should -Be $InputObject.TestProperty.Value
        }
        elseif ($DdbType -eq 'NULL')
        {
            $result.TestProperty.$DdbType | Should -Be $true
        }
        elseif (@('SS', 'NS', 'BS') -contains $DdbType)
        {
            $result.TestProperty.$DdbType | Out-String | Should -Be ($InputObject.TestProperty | Out-String)
        }
        elseif ($DdbType -eq 'L')
        {
            $result.TestProperty.$DdbType.$DdbSubType | Out-String | Should -Be ($InputObject.TestProperty | Out-String)
        }
        else
        {
            $result.TestProperty.$DdbType | Should -Be $InputObject.TestProperty
        }
    }

    It "ConvertTo-DDBItem throws an invalid type error when it receives an invalid type.'" {

        $hashtable = @{
            TestProperty = (Get-Date)
        }
        {ConvertTo-DDBItem -InputObject $hashtable} | Should -Throw "The data type 'System.DateTime' provided for the attribute 'TestProperty' is not supported for conversion into a DynamoDB attribute value."
    }

    It "ConvertTo-DDBItem converts a hashtable with an entry of PSType '<PSType>' to a hashtable containing the DDBattribute '<DdbType>' round trip'"  -TestCases $testCases {
        param ($InputObject, $DdbType, $DdbSubType)
        $result1 = ConvertTo-DDBItem -InputObject $InputObject
        $result2 = ConvertFrom-DDBItem -InputObject $result1
        $result3 = ConvertTo-DDBItem -InputObject $result2

        # The map datatype requires a different comparison than the other datatypes.
        if ($DdbType -eq 'M')
        {
            $result3.TestProperty.$DdbType.Value | Should -Be $InputObject.TestProperty.Value
        }
        elseif ($DdbType -eq 'NULL')
        {
            $result3.TestProperty.$DdbType | Should -Be $true
        }
        elseif (@('SS', 'NS', 'BS') -contains $DdbType)
        {
            $result3.TestProperty.$DdbType | Out-String | Should -Be ($InputObject.TestProperty | Out-String)
        }
        elseif ($DdbType -eq 'L')
        {
            $result3.TestProperty.$DdbType.$DdbSubType | Out-String | Should -Be ($InputObject.TestProperty | Out-String)
        }
        else
        {
            $result3.TestProperty.$DdbType | Should -Be $InputObject.TestProperty
        }
    }

    It "ConvertTo-DDBItem converts a hashtable containing a hashtable" {
        $inputObject = @{
            TestProperty = @{
                Map = @{
                    Person = 'kingarthur'
                }
            }
        }
        $result = ConvertTo-DDBItem -InputObject $inputObject
        $result.TestProperty.M.Map.M.Person.S | Should -Be  'kingarthur'
    }

    It "ConvertTo-DDBItem converts a list containing a list" {
        $inputObject = @{
            TestProperty = @(
                ,@(1)
            )
        }
        $result = ConvertTo-DDBItem -InputObject $inputObject
        $result.TestProperty.L[0].L[0].N | Should -Be '1'
    }

    It "ConvertTo-DDBItem converts a list containing a hashtable" {
        $inputObject = @{
            TestProperty = @(
                @{
                    Person = 'kingarthur'
                }
            )
        }
        $result = ConvertTo-DDBItem -InputObject $inputObject
        $result.TestProperty.L[0].M.Person.S | Should -Be  'kingarthur'
    }

    It "ConvertTo-DDBItem converts a hashtable containing a list" {
        $inputObject = @{
            TestProperty = @{
                List = @(1)
            }
        }
        $result = ConvertTo-DDBItem -InputObject $inputObject
        $result.TestProperty.M.List.L[0].N | Should -Be '1'
    }

    It "ConvertTo-DDBItem converts a hashtable containing a hashtable round trip" {
        $inputObject = @{
            TestProperty = @{
                Map = @{
                    Person = 'kingarthur'
                }
            }
        }
        $result1 = ConvertTo-DDBItem -InputObject $inputObject
        $result2 = ConvertFrom-DDBItem -InputObject $result1
        $result3 = ConvertTo-DDBItem -InputObject $result2
        $result3.TestProperty.M.Map.M.Person.S | Should -Be  'kingarthur'
    }

    It "ConvertTo-DDBItem converts a list containing a list round trip" {
        $inputObject = @{
            TestProperty = @(
                ,@(1)
            )
        }
        $result1 = ConvertTo-DDBItem -InputObject $inputObject
        $result2 = ConvertFrom-DDBItem -InputObject $result1
        $result3 = ConvertTo-DDBItem -InputObject $result2
        $result3.TestProperty.L[0].L[0].N | Should -Be '1'
    }

    It "ConvertTo-DDBItem converts a list containing a hashtable round trip" {
        $inputObject = @{
            TestProperty = @(
                @{
                    Person = 'kingarthur'
                }
            )
        }
        $result1 = ConvertTo-DDBItem -InputObject $inputObject
        $result2 = ConvertFrom-DDBItem -InputObject $result1
        $result3 = ConvertTo-DDBItem -InputObject $result2
        $result3.TestProperty.L[0].M.Person.S | Should -Be  'kingarthur'
    }

    It "ConvertTo-DDBItem converts a hashtable containing a list round trip" {
        $inputObject = @{
            TestProperty = @{
                List = @(1)
            }
        }
        $result1 = ConvertTo-DDBItem -InputObject $inputObject
        $result2 = ConvertFrom-DDBItem -InputObject $result1
        $result3 = ConvertTo-DDBItem -InputObject $result2
        $result3.TestProperty.M.List.L[0].N | Should -Be '1'
    }

    It "ConvertTo-DDBItem converts an empty array'" {
        $hashtable = @{
            List = @()
        }
        $result = ConvertTo-DDBItem -InputObject $hashtable
        $result.List.IsLSet | Should -Be $true
    }

    It "ConvertTo-DDBItem converts an empty arraylist'" {
        $hashtable = @{
            List = New-Object System.Collections.ArrayList
        }
        $result = ConvertTo-DDBItem -InputObject $hashtable
        $result.List.IsLSet | Should -Be $true
    }

    It "ConvertTo-DDBItem converts an empty generic list'" {
        $hashtable = @{
            List = New-Object System.Collections.Generic.List[String]
        }
        $result = ConvertTo-DDBItem -InputObject $hashtable
        $result.List.IsLSet | Should -Be $true
    }

    It "ConvertTo-DDBItem converts an empty hashtable'" {
        $hashtable = @{
            Map = @{}
        }
        $result = ConvertTo-DDBItem -InputObject $hashtable
        $result.Map.IsMSet | Should -Be $true
    }

    # Converting "from" empty lists and maps works well by default so no additional tests or round trip tests are provided.
}

Describe -Tag "Smoke" "AWS.PowerTools.DynamoDB ConvertFrom-DDBItem Unit Tests" {
    $testCases = @(
        @{
            Hashtable = @{
                TestProperty = 'kingarthur'
            }
            DdbType = 'S'
            PSTypeNickName = 'String'
            PSTypeExpected = 'System.String'
        },
        @{
            Hashtable = @{
                TestProperty = @('king', 'arthur')
            }
            DdbType = 'SS'
            PSTypeNickName = 'String[]'
            PSTypeExpected = 'System.Collections.Generic.HashSet`1[System.String]'
        },
        @{
            Hashtable = @{
                TestProperty = $true
            }
            DdbType = 'BOOL'
            PSTypeNickName = 'Boolean'
            PSTypeExpected = 'System.Boolean'
        },
        @{
            Hashtable = @{
                TestProperty = [Double]1
            }
            DdbType = 'N'
            PSTypeNickName = 'Double'
            PSTypeExpected = 'System.Double'
        },
        @{
            Hashtable = @{
                TestProperty = @(1,2,3)
            }
            DdbType = 'NS'
            PSTypeNickName = 'Double[]'
            PSTypeExpected = 'System.Collections.Generic.HashSet`1[System.Double]'
        },
        @{
            Hashtable = @{
                TestProperty = ([IO.MemoryStream]::new([Text.Encoding]::UTF8.GetBytes('king')))
            }
            DdbType = 'B'
            PSTypeNickName = 'System.IO.MemoryStream'
            PSTypeExpected = 'System.IO.MemoryStream'
        },
        @{
            Hashtable = @{
                TestProperty = @(([IO.MemoryStream]::new([Text.Encoding]::UTF8.GetBytes('king'))),([IO.MemoryStream]::new([Text.Encoding]::UTF8.GetBytes('king'))))
            }
            DdbType = 'BS'
            PSTypeNickName = 'System.IO.MemoryStream[]'
            PSTypeExpected = 'System.Collections.Generic.HashSet`1[System.IO.MemoryStream]'
        },
        @{
            Hashtable = @{
                TestProperty = [Int64]1
            }
            DdbType = 'NULL'
            PSTypeNickName = 'Null'
            PSTypeExpected = ''
        },
        @{
            Hashtable = @{
                TestProperty = @{
                    TestProperty = $null
                }
            }
            DdbType = 'M'
            PSTypeNickName = 'Hashtable'
            PSTypeExpected = 'System.Collections.Hashtable'
        },
        @{
            Hashtable = @{
                TestProperty = @(
                    1
                    'two'
                )
            }
            DdbType = 'L'
            PSTypeNickName = 'List`1'
            PSTypeExpected = 'System.Object[]'
        }
    )

    It "ConvertFrom-DDBItem converts a Dictionary containing the DDBattribute '<DdbType>' to a hashtable with a property of PSType '<PSTypeNickName>'" -TestCases $testCases {
        param ($Hashtable, $DdbType)

        $ddbDictionary = [System.Collections.Generic.Dictionary[String,Amazon.DynamoDBv2.Model.AttributeValue]]::new()

        # The map datatype requires a different setup than the other datatypes.
        if ($DdbType -eq 'M')
        {
            $stringAttribute = [Amazon.DynamoDBv2.Model.AttributeValue]@{
                'S' = 'arthur'
            }
            $stringDictionary = [System.Collections.Generic.Dictionary[String,Amazon.DynamoDBv2.Model.AttributeValue]]::new()
            $stringDictionary.Add('User', $stringAttribute)
            $ddbAttribute = [Amazon.DynamoDBv2.Model.AttributeValue]@{
                'M' = $stringDictionary
            }
        }
        else
        {
            $ddbAttribute = [Amazon.DynamoDBv2.Model.AttributeValue]@{
                $DdbType = $Hashtable.TestProperty
            }
        }

        $ddbDictionary['TestProperty'] = $ddbAttribute

        $resultHashtable = ConvertFrom-DDBItem -InputObject $ddbDictionary

        # The map datatype requires a different comparison than the other datatypes.
        if ($DdbType -eq 'M')
        {
            $resultHashtable.TestProperty.User | Should -Be 'arthur'
        }
        elseif ($DdbType -eq 'NULL')
        {
            $resultHashtable.TestProperty | Should -Be $null
        }
        else
        {
            $resultHashtable.TestProperty | Should -Be $Hashtable.TestProperty
        }

        if ($DdbType -ne 'NULL')
        {
            $resultHashTable.TestProperty.GetType().ToString() | Should -Be $PSTypeExpected
        }
    }

    It "ConvertFrom-DDBItem converts a Dictionary containing the DDBattribute '<DdbType>' to a hashtable with a property of PSType '<PSTypeNickName>' round trip" -TestCases $testCases {
        param ($Hashtable, $DdbType)

        $ddbDictionary = [System.Collections.Generic.Dictionary[String,Amazon.DynamoDBv2.Model.AttributeValue]]::new()

        # The map datatype requires a different setup than the other datatypes.
        if ($DdbType -eq 'M')
        {
            $stringAttribute = [Amazon.DynamoDBv2.Model.AttributeValue]@{
                'S' = 'arthur'
            }
            $stringDictionary = [System.Collections.Generic.Dictionary[String,Amazon.DynamoDBv2.Model.AttributeValue]]::new()
            $stringDictionary.Add('User', $stringAttribute)
            $ddbAttribute = [Amazon.DynamoDBv2.Model.AttributeValue]@{
                'M' = $stringDictionary
            }
        }
        else
        {
            $ddbAttribute = [Amazon.DynamoDBv2.Model.AttributeValue]@{
                $DdbType = $Hashtable.TestProperty
            }
        }

        $ddbDictionary['TestProperty'] = $ddbAttribute

        $resultHashtable1 = ConvertFrom-DDBItem -InputObject $ddbDictionary
        $resultHashtable2 = ConvertTo-DDBItem -InputObject $resultHashtable1
        $resultHashtable3 = ConvertFrom-DDBItem -InputObject $resultHashtable2

        # The map datatype requires a different comparison than the other datatypes.
        if ($DdbType -eq 'M')
        {
            $resultHashtable3.TestProperty.User | Should -Be 'arthur'
        }
        elseif ($DdbType -eq 'NULL')
        {
            $resultHashtable3.TestProperty | Should -Be $null
        }
        else
        {
            $resultHashtable3.TestProperty | Should -Be $Hashtable.TestProperty
        }

        if ($DdbType -ne 'NULL')
        {
            $resultHashTable3.TestProperty.GetType().ToString() | Should -Be $PSTypeExpected
        }
    }

    It "ConvertFrom-DDBItem converts a map containing a map" {
        $stringDictionary = [System.Collections.Generic.Dictionary[String,Amazon.DynamoDBv2.Model.AttributeValue]]::new()
        $stringAttribute = [Amazon.DynamoDBv2.Model.AttributeValue]@{
            'S' = 'arthur'
        }
        $stringDictionary.Add('Id', $stringAttribute)
        $mapDictionary = [System.Collections.Generic.Dictionary[String,Amazon.DynamoDBv2.Model.AttributeValue]]::new()
        $mapAttribute2 = [Amazon.DynamoDBv2.Model.AttributeValue]@{
            'M' = $stringDictionary
        }
        $mapDictionary.Add('User', $mapAttribute2)
        $mapAttribute1 = [Amazon.DynamoDBv2.Model.AttributeValue]@{
            'M' = $mapDictionary
        }
        $inputObject = [System.Collections.Generic.Dictionary[String,Amazon.DynamoDBv2.Model.AttributeValue]]::new()
        $inputObject['TestProperty'] = $mapAttribute1
        $result = ConvertFrom-DDBItem -InputObject $inputObject
        $result.TestProperty.User.Id | Should -Be  'arthur'
    }

    It "ConvertFrom-DDBItem converts a list containing a list" {
        $stringList = [System.Collections.Generic.List[Amazon.DynamoDBv2.Model.AttributeValue]]::new()
        $stringAttribute = [Amazon.DynamoDBv2.Model.AttributeValue]@{
            'S' = 'arthur'
        }
        $stringList.Add($stringAttribute)
        $stringList.Add($stringAttribute)
        $listAttribute = [Amazon.DynamoDBv2.Model.AttributeValue]@{
            'L' = $stringList
        }
        $listList = [System.Collections.Generic.List[Amazon.DynamoDBv2.Model.AttributeValue]]::new()
        $listList.Add($listAttribute)
        $listList.Add($listAttribute)
        $listAttribute = [Amazon.DynamoDBv2.Model.AttributeValue]@{
            'L' = $listList
        }
        $inputObject = [System.Collections.Generic.Dictionary[String,Amazon.DynamoDBv2.Model.AttributeValue]]::new()
        $inputObject['TestProperty'] = $listAttribute
        $result = ConvertFrom-DDBItem -InputObject $inputObject
        $result.TestProperty[0][0] | Should -Be  'arthur'
    }

    It "ConvertFrom-DDBItem converts a list containing a map" {

        $stringDictionary = [System.Collections.Generic.Dictionary[String,Amazon.DynamoDBv2.Model.AttributeValue]]::new()
        $stringAttribute = [Amazon.DynamoDBv2.Model.AttributeValue]@{
            'S' = 'arthur'
        }
        $stringDictionary.Add('Id', $stringAttribute)
        $mapDictionary = [System.Collections.Generic.Dictionary[String,Amazon.DynamoDBv2.Model.AttributeValue]]::new()
        $mapAttribute = [Amazon.DynamoDBv2.Model.AttributeValue]@{
            'M' = $stringDictionary
        }

        $mapList = [System.Collections.Generic.List[Amazon.DynamoDBv2.Model.AttributeValue]]::new()
        $mapList.Add($mapAttribute)
        $mapList.Add($mapAttribute)
        $listAttribute = [Amazon.DynamoDBv2.Model.AttributeValue]@{
            'L' = $mapList
        }
        $inputObject = [System.Collections.Generic.Dictionary[String,Amazon.DynamoDBv2.Model.AttributeValue]]::new()
        $inputObject['TestProperty'] = $listAttribute
        $result = ConvertFrom-DDBItem -InputObject $inputObject
        $result.TestProperty[0].Id | Should -Be  'arthur'
    }

    It "ConvertFrom-DDBItem converts a map containing a list" {
        $stringList = [System.Collections.Generic.List[Amazon.DynamoDBv2.Model.AttributeValue]]::new()
        $stringAttribute = [Amazon.DynamoDBv2.Model.AttributeValue]@{
            'S' = 'arthur'
        }
        $stringList.Add($stringAttribute)
        $stringList.Add($stringAttribute)
        $listAttribute = [Amazon.DynamoDBv2.Model.AttributeValue]@{
            'L' = $stringList
        }
        $mapDictionary = [System.Collections.Generic.Dictionary[String,Amazon.DynamoDBv2.Model.AttributeValue]]::new()
        $mapDictionary.Add('User', $listAttribute)
        $mapAttribute = [Amazon.DynamoDBv2.Model.AttributeValue]@{
            'M' = $mapDictionary
        }
        $inputObject = [System.Collections.Generic.Dictionary[String,Amazon.DynamoDBv2.Model.AttributeValue]]::new()
        $inputObject['TestProperty'] = $mapAttribute
        $result = ConvertFrom-DDBItem -InputObject $inputObject
        $result.TestProperty.User[0] | Should -Be 'arthur'
    }

    It "ConvertFrom-DDBItem converts a map containing a map round trip" {
        $stringDictionary = [System.Collections.Generic.Dictionary[String,Amazon.DynamoDBv2.Model.AttributeValue]]::new()
        $stringAttribute = [Amazon.DynamoDBv2.Model.AttributeValue]@{
            'S' = 'arthur'
        }
        $stringDictionary.Add('Id', $stringAttribute)
        $mapDictionary = [System.Collections.Generic.Dictionary[String,Amazon.DynamoDBv2.Model.AttributeValue]]::new()
        $mapAttribute2 = [Amazon.DynamoDBv2.Model.AttributeValue]@{
            'M' = $stringDictionary
        }
        $mapDictionary.Add('User', $mapAttribute2)
        $mapAttribute1 = [Amazon.DynamoDBv2.Model.AttributeValue]@{
            'M' = $mapDictionary
        }
        $inputObject = [System.Collections.Generic.Dictionary[String,Amazon.DynamoDBv2.Model.AttributeValue]]::new()
        $inputObject['TestProperty'] = $mapAttribute1
        $result1 = ConvertFrom-DDBItem -InputObject $inputObject
        $result2 = ConvertTo-DDBItem -InputObject $result1
        $result3 = ConvertFrom-DDBItem -InputObject $result2
        $result3.TestProperty.User.Id | Should -Be  'arthur'
    }

    It "ConvertFrom-DDBItem converts a list containing a list round trip" {
        $stringList = [System.Collections.Generic.List[Amazon.DynamoDBv2.Model.AttributeValue]]::new()
        $stringAttribute = [Amazon.DynamoDBv2.Model.AttributeValue]@{
            'S' = 'arthur'
        }
        $stringList.Add($stringAttribute)
        $stringList.Add($stringAttribute)
        $listAttribute = [Amazon.DynamoDBv2.Model.AttributeValue]@{
            'L' = $stringList
        }
        $listList = [System.Collections.Generic.List[Amazon.DynamoDBv2.Model.AttributeValue]]::new()
        $listList.Add($listAttribute)
        $listList.Add($listAttribute)
        $listAttribute = [Amazon.DynamoDBv2.Model.AttributeValue]@{
            'L' = $listList
        }
        $inputObject = [System.Collections.Generic.Dictionary[String,Amazon.DynamoDBv2.Model.AttributeValue]]::new()
        $inputObject['TestProperty'] = $listAttribute
        $result1 = ConvertFrom-DDBItem -InputObject $inputObject
        $result2 = ConvertTo-DDBItem -InputObject $result1
        $result3 = ConvertFrom-DDBItem -InputObject $result2
        $result3.TestProperty[0][0] | Should -Be 'arthur'
    }

    It "ConvertFrom-DDBItem converts a list containing a map round trip" {
        $stringDictionary = [System.Collections.Generic.Dictionary[String,Amazon.DynamoDBv2.Model.AttributeValue]]::new()
        $stringAttribute = [Amazon.DynamoDBv2.Model.AttributeValue]@{
            'S' = 'arthur'
        }
        $stringDictionary.Add('Id', $stringAttribute)
        $mapDictionary = [System.Collections.Generic.Dictionary[String,Amazon.DynamoDBv2.Model.AttributeValue]]::new()
        $mapAttribute = [Amazon.DynamoDBv2.Model.AttributeValue]@{
            'M' = $stringDictionary
        }

        $mapList = [System.Collections.Generic.List[Amazon.DynamoDBv2.Model.AttributeValue]]::new()
        $mapList.Add($mapAttribute)
        $mapList.Add($mapAttribute)
        $listAttribute = [Amazon.DynamoDBv2.Model.AttributeValue]@{
            'L' = $mapList
        }
        $inputObject = [System.Collections.Generic.Dictionary[String,Amazon.DynamoDBv2.Model.AttributeValue]]::new()
        $inputObject['TestProperty'] = $listAttribute

        $result1 = ConvertFrom-DDBItem -InputObject $inputObject
        $result2 = ConvertTo-DDBItem -InputObject $result1
        $result3 = ConvertFrom-DDBItem -InputObject $result2
        $result3.TestProperty[0].Id | Should -Be  'arthur'
    }

    It "ConvertFrom-DDBItem converts a map containing a list round trip" {
        $stringList = [System.Collections.Generic.List[Amazon.DynamoDBv2.Model.AttributeValue]]::new()
        $stringAttribute = [Amazon.DynamoDBv2.Model.AttributeValue]@{
            'S' = 'arthur'
        }
        $stringList.Add($stringAttribute)
        $stringList.Add($stringAttribute)
        $listAttribute = [Amazon.DynamoDBv2.Model.AttributeValue]@{
            'L' = $stringList
        }
        $mapDictionary = [System.Collections.Generic.Dictionary[String,Amazon.DynamoDBv2.Model.AttributeValue]]::new()
        $mapDictionary.Add('User', $listAttribute)
        $mapAttribute = [Amazon.DynamoDBv2.Model.AttributeValue]@{
            'M' = $mapDictionary
        }
        $inputObject = [System.Collections.Generic.Dictionary[String,Amazon.DynamoDBv2.Model.AttributeValue]]::new()
        $inputObject['TestProperty'] = $mapAttribute
        $result1 = ConvertFrom-DDBItem -InputObject $inputObject
        $result2 = ConvertTo-DDBItem -InputObject $result1
        $result3 = ConvertFrom-DDBItem -InputObject $result2
        $result3.TestProperty.User[0] | Should -Be 'arthur'
    }

    $testCases = @(
            @{
                NumericType = 'System.Int16'
            },
            @{
                NumericType = 'System.UInt16'
            },
            @{
                NumericType = 'System.Int32'
            },
            @{
                NumericType = 'System.UInt32'
            },
            @{
                NumericType = 'System.Int64'
            },
            @{
                NumericType = 'System.UInt64'
            },
            @{
                NumericType = 'System.Decimal'
            },
            @{
                NumericType = 'System.Single'
            },
            @{
                NumericType = 'System.Double'
            }
    )
    It "ConvertFrom-DDBItem converts numeric values to type '<NumericType>' when specified by the NumericType parameter." -TestCases $testCases {
        param ($NumericType)

        $inputObject = [System.Collections.Generic.Dictionary[String,Amazon.DynamoDBv2.Model.AttributeValue]]::new()
        $numericAttribute = [Amazon.DynamoDBv2.Model.AttributeValue]@{
            'N' = 1
        }
        $inputObject.Add('TestProperty', $numericAttribute)

        $result = ConvertFrom-DDBItem -InputObject $inputObject -NumericType $NumericType
        $result.TestProperty | Should -BeOfType $NumericType
    }
}
