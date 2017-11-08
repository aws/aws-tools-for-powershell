/*******************************************************************************
 *  Copyright 2012-2015 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.PowerShell.Common;
using Amazon.Runtime;
using Amazon.Greengrass;
using Amazon.Greengrass.Model;

namespace Amazon.PowerShell.Cmdlets.GG
{
    /// <summary>
    /// Retrieves information about a Lambda function definition, such as its creation time
    /// and latest version.
    /// </summary>
    [Cmdlet("Get", "GGFunctionDefinition")]
    [OutputType("Amazon.Greengrass.Model.GetFunctionDefinitionResponse")]
    [AWSCmdlet("Calls the AWS Greengrass GetFunctionDefinition API operation.", Operation = new[] {"GetFunctionDefinition"})]
    [AWSCmdletOutput("Amazon.Greengrass.Model.GetFunctionDefinitionResponse",
        "This cmdlet returns a Amazon.Greengrass.Model.GetFunctionDefinitionResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetGGFunctionDefinitionCmdlet : AmazonGreengrassClientCmdlet, IExecutor
    {
        
        #region Parameter FunctionDefinitionId
        /// <summary>
        /// <para>
        /// the unique Id of the lambda definition
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String FunctionDefinitionId { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            context.FunctionDefinitionId = this.FunctionDefinitionId;
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.Greengrass.Model.GetFunctionDefinitionRequest();
            
            if (cmdletContext.FunctionDefinitionId != null)
            {
                request.FunctionDefinitionId = cmdletContext.FunctionDefinitionId;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response;
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response,
                    Notes = notes
                };
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
        
        private Amazon.Greengrass.Model.GetFunctionDefinitionResponse CallAWSServiceOperation(IAmazonGreengrass client, Amazon.Greengrass.Model.GetFunctionDefinitionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Greengrass", "GetFunctionDefinition");
            try
            {
                #if DESKTOP
                return client.GetFunctionDefinition(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.GetFunctionDefinitionAsync(request);
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
        
        internal partial class CmdletContext : ExecutorContext
        {
            public System.String FunctionDefinitionId { get; set; }
        }
        
    }
}
