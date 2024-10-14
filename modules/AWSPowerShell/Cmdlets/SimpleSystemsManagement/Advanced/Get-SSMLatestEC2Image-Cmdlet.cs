/*******************************************************************************
 *  Copyright 2012-2019 Amazon.com, Inc. or its affiliates. All Rights Reserved.
 *  Licensed under the Apache License, Version 2.0 (the "License"). You may not use
 *  this file except in compliance with the License. A copy of the License is located at
 *
 *  http://aws.amazon.com/apache2.0
 *
 *  or in the "license" file accompanying this file.
 *  This file is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR
 *  CONDITIONS OF ANY KIND, either express or implied. See the License for the
 *  specific language governing permissions and limitations under the License.
 * *****************************************************************************
 *
 *  AWS Tools for Windows (TM) PowerShell (TM)
 *
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Text.RegularExpressions;
using Amazon.PowerShell.Common;
using Amazon.Runtime;
using Amazon.SimpleSystemsManagement;
using Amazon.SimpleSystemsManagement.Model;
using ThirdParty.Json.LitJson;

namespace Amazon.PowerShell.Cmdlets.SSM
{
    /// <summary>
    /// Retrieves the latest EC2 AMIs (Amazon Machine Images) from AWS Systems Manager parameters by calling Get-SSMParametersByPath or Get-SSMParameterValue.
    /// </summary>
    [Cmdlet("Get", "SSMLatestEC2Image")]
    [OutputType("PSObject")]
    [AWSCmdlet("Retrieves the latest EC2 AMIs (Amazon Machine Images) from AWS Systems Manager parameters by calling Get-SSMParametersByPath or Get-SSMParameterValue.")]
    [AWSCmdletOutput("PSObject or System.String",
        "This cmdlet returns a collection of PSObjects when listing AMIs. When -ImageName is specified without using wildcard characters, the cmdlet returns only the AMI's identifier as a string.",
        "The service call response (type Amazon.SimpleSystemsManagement.Model.GetParametersByPathResponse or Amazon.SimpleSystemsManagement.Model.GetParametersResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetSSMLatestEC2ImageCmdlet : AmazonSimpleSystemsManagementClientCmdlet
    {
        #region Parameter Path
        /// <summary>
        /// <para>
        /// The partial hierarchy for the parameter under the /aws/service/ prefix representing the type of images to list.
        /// </para>
        /// </summary>
        [ValidateSet("ami-windows-latest", "ami-amazon-linux-latest")]
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String Path { get; set; }
        #endregion

        #region Parameter ImageName
        /// <summary>
        /// <para>
        /// The name of the parameter containing the image information. Wildcard characters '*' and '?' can be used to filter multiple AMIs.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        public System.String ImageName { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            var parameters = new Dictionary<string, object>(MyInvocation.BoundParameters);
            parameters.Remove(nameof(Path));
            parameters.Remove(nameof(ImageName));

            bool matchSingleImage = ImageName != null && !ImageName.Contains('*') && !ImageName.Contains('?');

#if DESKTOP
            var cmdlet = matchSingleImage ? "Get-SSMParameterValue" : "Get-SSMParametersByPath";
#else
            var cmdlet = matchSingleImage ? new CmdletInfo("Get-SSMParameterValue", typeof(GetSSMParameterValueCmdlet))
                                          : new CmdletInfo("Get-SSMParametersByPath", typeof(GetSSMParametersByPathCmdlet));
#endif

            var path = $"/aws/service/{Path}";
            Regex regex = null;
            if (matchSingleImage)
            {
                parameters.Add(nameof(GetSSMParameterValueCmdlet.Name), $"{path}/{ImageName}");
                parameters.Add(nameof(GetSSMParameterValueCmdlet.Select), nameof(GetParametersResponse.Parameters));
            }
            else
            {
                parameters.Add(nameof(GetSSMParametersByPathCmdlet.Path), path);
                parameters.Add(nameof(GetSSMParametersByPathCmdlet.Select), nameof(GetParametersByPathResponse.Parameters));
                if (ImageName != null)
                {
                    regex = new Regex($"^{path}/{Regex.Escape(ImageName). Replace("\\*", ".*").Replace("\\?", ".")}$", RegexOptions.IgnoreCase);
                }
            }

            IEnumerable<PSObject> results = ExecuteCmdlet(cmdlet, parameters);

            var output = new CmdletOutput
            {
                PipelineOutput = results
            };

            if (results != null)
            {
                //Best effort conversion of a Parameter to a PSObject, if the value is in json, we will try to parse it and extract the image_id field.
                output.PipelineOutput = results.Select<PSObject, object>(psObject =>
                {
                    var ssmParameter = psObject.BaseObject as Parameter;
                    if (ssmParameter == null || !(regex?.IsMatch(ssmParameter.Name) ?? true))
                    {
                        return null;
                    }
                    string value = ssmParameter.Value;
                    if (value.Contains('{'))
                    {
                        try
                        {
                            var jsonData = JsonMapper.ToObject(value);
                            var imageId = jsonData["image_id"];
                            if (imageId?.IsString ?? false)
                            {
                                value = (string)imageId;
                            }
                        }
                        catch
                        {
                            //If we can't parse the value as json and extract image_id, we will return the full value
                        }
                    }

                    if (matchSingleImage)
                    {
                        return value;
                    }
                    else
                    {
                        var result = new PSObject();
                        result.Properties.Add(new PSNoteProperty("Name", ssmParameter.Name.Substring(path.Length + 1)));
                        result.Properties.Add(new PSNoteProperty("Value", value));
                        return result;
                    }
                }).Where(value => value != null).ToArray();
            }

            ProcessOutput(output);
        }
    }
}
