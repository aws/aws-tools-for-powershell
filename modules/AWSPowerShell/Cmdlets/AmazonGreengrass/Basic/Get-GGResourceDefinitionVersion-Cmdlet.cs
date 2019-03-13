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
    /// Retrieves information about a resource definition version, including which resources
    /// are included in the version.
    /// </summary>
    [Cmdlet("Get", "GGResourceDefinitionVersion")]
    [OutputType("Amazon.Greengrass.Model.GetResourceDefinitionVersionResponse")]
    [AWSCmdlet("Calls the AWS Greengrass GetResourceDefinitionVersion API operation.", Operation = new[] {"GetResourceDefinitionVersion"})]
    [AWSCmdletOutput("Amazon.Greengrass.Model.GetResourceDefinitionVersionResponse",
        "This cmdlet returns a Amazon.Greengrass.Model.GetResourceDefinitionVersionResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetGGResourceDefinitionVersionCmdlet : AmazonGreengrassClientCmdlet, IExecutor
    {
        
        #region Parameter ResourceDefinitionId
        /// <summary>
        /// <para>
        /// The ID of the resource definition.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ResourceDefinitionId { get; set; }
        #endregion
        
        #region Parameter ResourceDefinitionVersionId
        /// <summary>
        /// <para>
        /// The ID of the resource definition
        /// version.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String ResourceDefinitionVersionId { get; set; }
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
            
            context.ResourceDefinitionId = this.ResourceDefinitionId;
            context.ResourceDefinitionVersionId = this.ResourceDefinitionVersionId;
            
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
            var request = new Amazon.Greengrass.Model.GetResourceDefinitionVersionRequest();
            
            if (cmdletContext.ResourceDefinitionId != null)
            {
                request.ResourceDefinitionId = cmdletContext.ResourceDefinitionId;
            }
            if (cmdletContext.ResourceDefinitionVersionId != null)
            {
                request.ResourceDefinitionVersionId = cmdletContext.ResourceDefinitionVersionId;
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
        
        private Amazon.Greengrass.Model.GetResourceDefinitionVersionResponse CallAWSServiceOperation(IAmazonGreengrass client, Amazon.Greengrass.Model.GetResourceDefinitionVersionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Greengrass", "GetResourceDefinitionVersion");
            try
            {
                #if DESKTOP
                return client.GetResourceDefinitionVersion(request);
                #elif CORECLR
                return client.GetResourceDefinitionVersionAsync(request).GetAwaiter().GetResult();
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
            public System.String ResourceDefinitionId { get; set; }
            public System.String ResourceDefinitionVersionId { get; set; }
        }
        
    }
}
