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
    /// Retrieves information about a device definition version.
    /// </summary>
    [Cmdlet("Get", "GGDeviceDefinitionVersion")]
    [OutputType("Amazon.Greengrass.Model.GetDeviceDefinitionVersionResponse")]
    [AWSCmdlet("Calls the AWS Greengrass GetDeviceDefinitionVersion API operation.", Operation = new[] {"GetDeviceDefinitionVersion"})]
    [AWSCmdletOutput("Amazon.Greengrass.Model.GetDeviceDefinitionVersionResponse",
        "This cmdlet returns a Amazon.Greengrass.Model.GetDeviceDefinitionVersionResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetGGDeviceDefinitionVersionCmdlet : AmazonGreengrassClientCmdlet, IExecutor
    {
        
        #region Parameter DeviceDefinitionId
        /// <summary>
        /// <para>
        /// The ID of the device definition.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String DeviceDefinitionId { get; set; }
        #endregion
        
        #region Parameter DeviceDefinitionVersionId
        /// <summary>
        /// <para>
        /// The ID of the device definition
        /// version.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String DeviceDefinitionVersionId { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// The token for the next set of results, or ''null''
        /// if there are no additional results.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String NextToken { get; set; }
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
            
            context.DeviceDefinitionId = this.DeviceDefinitionId;
            context.DeviceDefinitionVersionId = this.DeviceDefinitionVersionId;
            context.NextToken = this.NextToken;
            
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
            var request = new Amazon.Greengrass.Model.GetDeviceDefinitionVersionRequest();
            
            if (cmdletContext.DeviceDefinitionId != null)
            {
                request.DeviceDefinitionId = cmdletContext.DeviceDefinitionId;
            }
            if (cmdletContext.DeviceDefinitionVersionId != null)
            {
                request.DeviceDefinitionVersionId = cmdletContext.DeviceDefinitionVersionId;
            }
            if (cmdletContext.NextToken != null)
            {
                request.NextToken = cmdletContext.NextToken;
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
        
        private Amazon.Greengrass.Model.GetDeviceDefinitionVersionResponse CallAWSServiceOperation(IAmazonGreengrass client, Amazon.Greengrass.Model.GetDeviceDefinitionVersionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Greengrass", "GetDeviceDefinitionVersion");
            try
            {
                #if DESKTOP
                return client.GetDeviceDefinitionVersion(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.GetDeviceDefinitionVersionAsync(request);
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
            public System.String DeviceDefinitionId { get; set; }
            public System.String DeviceDefinitionVersionId { get; set; }
            public System.String NextToken { get; set; }
        }
        
    }
}
