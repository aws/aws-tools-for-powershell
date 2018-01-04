/*******************************************************************************
 *  Copyright 2012-2018 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using System.IO;
using System.Management.Automation;
using Amazon.PowerShell.Common;
using Amazon.Runtime;
using Amazon.IdentityManagement;
using Amazon.IdentityManagement.Model;

namespace Amazon.PowerShell.Cmdlets.IAM
{
    /// <summary>
    /// Retrieves a credential report for the AWS account. For more information about the
    /// credential report, see <a href="http://docs.aws.amazon.com/IAM/latest/UserGuide/credential-reports.html">Getting
    /// Credential Reports</a> in the <i>Using IAM</i> guide.
    /// The report is contained in a System.IO.Memory stream in the output. To have the cmdlet output the report
    /// contents as a single string object, use the -Raw switch. To have the report output as an array of lines
    /// use the -AsTextArray switch.
    /// </summary>
    [Cmdlet("Get", "IAMCredentialReport")]
    [OutputType(new Type[] { typeof(Amazon.IdentityManagement.Model.GetCredentialReportResponse), typeof(string[]), typeof(string)})]
    [AWSCmdlet("Calls the AWS Identity and Access Management GetCredentialReport API operation.", Operation = new[] { "GetCredentialReport" })]
    [AWSCmdletOutput("Amazon.IdentityManagement.Model.GetCredentialReportResponse",
        "This cmdlet returns an Amazon.IdentityManagement.Model.GetCredentialReportResponse object containing multiple properties and a memory stream with the report contents or the contents of the report as an array of strings or one consolidated string. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class GetIAMCredentialReportCmdlet : AmazonIdentityManagementServiceClientCmdlet, IExecutor
    {

        #region Parameter AsTextArray
        /// <summary>
        /// If set the cmdlet will process the the memory stream contained in the service response
        /// to the pipeline as a series of lines of text.
        /// </summary>
        [Parameter]
        [Alias("SplitLines")]
        public SwitchParameter AsTextArray { get; set; }
        #endregion

        #region Parameter Raw
        /// <summary>
        /// If set the cmdlet output will be a single string containing all of the lines in the
        /// report/
        /// </summary>
        [Parameter]
        public SwitchParameter Raw { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };

            if (AsTextArray.IsPresent)
                context.AsTextArray = true;
            if (Raw.IsPresent)
                context.Raw = true;

            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new GetCredentialReportRequest();

            var client = Client ?? CreateClient(context.Credentials, context.Region);
            CmdletOutput output;
            
            // issue call
            try
            {
                var response = CallAWSServiceOperation(client, request);

                output = new CmdletOutput
                {
                    ServiceResponse = response
                };

                if (cmdletContext.AsTextArray || cmdletContext.Raw)
                {
                    using (var reader = new StreamReader(response.Content))
                    {
                        if (cmdletContext.Raw)
                        {
                            output.PipelineOutput = reader.ReadToEnd();
                        }
                        else
                        {
                            var lines = new List<string>();
                            var line = reader.ReadLine();
                            while (line != null)
                            {
                                lines.Add(line);
                                line = reader.ReadLine();
                            }
                            output.PipelineOutput = lines;
                        }
                    }
                }
                else
                {
                    output.PipelineOutput = response;
                }
            }
            catch (Exception e)
            {
                output = new CmdletOutput { ErrorResponse = e };
            }
            
            return output;
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }

        #endregion

        #region AWS Service Operation Call

        private Amazon.IdentityManagement.Model.GetCredentialReportResponse CallAWSServiceOperation(IAmazonIdentityManagementService client, Amazon.IdentityManagement.Model.GetCredentialReportRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Identity and Access Management", "GetCredentialReport");

            try
            {
#if DESKTOP
                return client.GetCredentialReport(request);
#elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.GetCredentialReportAsync(request);
                return task.Result;
#else
#error "Unknown build edition"
#endif
            }
            catch (AmazonServiceException exc)
            {
                var webException = exc.InnerException as System.Net.WebException;
                if (webException != null)
                {
                    throw new Exception(Utils.Common.FormatNameResolutionFailureMessage(client.Config, webException.Message), webException);
                }

                throw;
            }
        }

        #endregion

        internal class CmdletContext : ExecutorContext
        {
            public bool AsTextArray { get; set; }
            public bool Raw { get; set; }
        }
        
    }
}
