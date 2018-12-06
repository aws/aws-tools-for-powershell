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
    /// Retrieves information about a connector definition version, including the connectors
    /// that the version contains. Connectors are prebuilt modules that interact with local
    /// infrastructure, device protocols, AWS, and other cloud services.
    /// </summary>
    [Cmdlet("Get", "GGConnectorDefinitionVersion")]
    [OutputType("Amazon.Greengrass.Model.GetConnectorDefinitionVersionResponse")]
    [AWSCmdlet("Calls the AWS Greengrass GetConnectorDefinitionVersion API operation.", Operation = new[] {"GetConnectorDefinitionVersion"})]
    [AWSCmdletOutput("Amazon.Greengrass.Model.GetConnectorDefinitionVersionResponse",
        "This cmdlet returns a Amazon.Greengrass.Model.GetConnectorDefinitionVersionResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetGGConnectorDefinitionVersionCmdlet : AmazonGreengrassClientCmdlet, IExecutor
    {
        
        #region Parameter ConnectorDefinitionId
        /// <summary>
        /// <para>
        /// The ID of the connector definition.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ConnectorDefinitionId { get; set; }
        #endregion
        
        #region Parameter ConnectorDefinitionVersionId
        /// <summary>
        /// <para>
        /// The ID of the connector definition
        /// version.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String ConnectorDefinitionVersionId { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// The token for the next set of results, or ''null''
        /// if there are no additional results.
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> This parameter is only used if you are manually controlling output pagination of the service API call.
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
            
            context.ConnectorDefinitionId = this.ConnectorDefinitionId;
            context.ConnectorDefinitionVersionId = this.ConnectorDefinitionVersionId;
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
            var request = new Amazon.Greengrass.Model.GetConnectorDefinitionVersionRequest();
            
            if (cmdletContext.ConnectorDefinitionId != null)
            {
                request.ConnectorDefinitionId = cmdletContext.ConnectorDefinitionId;
            }
            if (cmdletContext.ConnectorDefinitionVersionId != null)
            {
                request.ConnectorDefinitionVersionId = cmdletContext.ConnectorDefinitionVersionId;
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
        
        private Amazon.Greengrass.Model.GetConnectorDefinitionVersionResponse CallAWSServiceOperation(IAmazonGreengrass client, Amazon.Greengrass.Model.GetConnectorDefinitionVersionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Greengrass", "GetConnectorDefinitionVersion");
            try
            {
                #if DESKTOP
                return client.GetConnectorDefinitionVersion(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.GetConnectorDefinitionVersionAsync(request);
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
            public System.String ConnectorDefinitionId { get; set; }
            public System.String ConnectorDefinitionVersionId { get; set; }
            public System.String NextToken { get; set; }
        }
        
    }
}
