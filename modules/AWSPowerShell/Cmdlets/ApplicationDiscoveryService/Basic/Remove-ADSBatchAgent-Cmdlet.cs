/*******************************************************************************
 *  Copyright Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.ApplicationDiscoveryService;
using Amazon.ApplicationDiscoveryService.Model;

namespace Amazon.PowerShell.Cmdlets.ADS
{
    /// <summary>
    /// Deletes one or more agents or collectors as specified by ID. Deleting an agent or
    /// collector does not delete the previously discovered data. To delete the data collected,
    /// use <c>StartBatchDeleteConfigurationTask</c>.
    /// </summary>
    [Cmdlet("Remove", "ADSBatchAgent", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("Amazon.ApplicationDiscoveryService.Model.BatchDeleteAgentError")]
    [AWSCmdlet("Calls the AWS Application Discovery Service BatchDeleteAgents API operation.", Operation = new[] {"BatchDeleteAgents"}, SelectReturnType = typeof(Amazon.ApplicationDiscoveryService.Model.BatchDeleteAgentsResponse))]
    [AWSCmdletOutput("Amazon.ApplicationDiscoveryService.Model.BatchDeleteAgentError or Amazon.ApplicationDiscoveryService.Model.BatchDeleteAgentsResponse",
        "This cmdlet returns a collection of Amazon.ApplicationDiscoveryService.Model.BatchDeleteAgentError objects.",
        "The service call response (type Amazon.ApplicationDiscoveryService.Model.BatchDeleteAgentsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class RemoveADSBatchAgentCmdlet : AmazonApplicationDiscoveryServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter DeleteAgent
        /// <summary>
        /// <para>
        /// <para> The list of agents to delete. </para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("DeleteAgents")]
        public Amazon.ApplicationDiscoveryService.Model.DeleteAgent[] DeleteAgent { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Errors'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ApplicationDiscoveryService.Model.BatchDeleteAgentsResponse).
        /// Specifying the name of a property of type Amazon.ApplicationDiscoveryService.Model.BatchDeleteAgentsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Errors";
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.DeleteAgent), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-ADSBatchAgent (BatchDeleteAgents)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ApplicationDiscoveryService.Model.BatchDeleteAgentsResponse, RemoveADSBatchAgentCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.DeleteAgent != null)
            {
                context.DeleteAgent = new List<Amazon.ApplicationDiscoveryService.Model.DeleteAgent>(this.DeleteAgent);
            }
            #if MODULAR
            if (this.DeleteAgent == null && ParameterWasBound(nameof(this.DeleteAgent)))
            {
                WriteWarning("You are passing $null as a value for parameter DeleteAgent which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            
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
            var request = new Amazon.ApplicationDiscoveryService.Model.BatchDeleteAgentsRequest();
            
            if (cmdletContext.DeleteAgent != null)
            {
                request.DeleteAgents = cmdletContext.DeleteAgent;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                object pipelineOutput = null;
                pipelineOutput = cmdletContext.Select(response, this);
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response
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
        
        private Amazon.ApplicationDiscoveryService.Model.BatchDeleteAgentsResponse CallAWSServiceOperation(IAmazonApplicationDiscoveryService client, Amazon.ApplicationDiscoveryService.Model.BatchDeleteAgentsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Application Discovery Service", "BatchDeleteAgents");
            try
            {
                #if DESKTOP
                return client.BatchDeleteAgents(request);
                #elif CORECLR
                return client.BatchDeleteAgentsAsync(request).GetAwaiter().GetResult();
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
            public List<Amazon.ApplicationDiscoveryService.Model.DeleteAgent> DeleteAgent { get; set; }
            public System.Func<Amazon.ApplicationDiscoveryService.Model.BatchDeleteAgentsResponse, RemoveADSBatchAgentCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Errors;
        }
        
    }
}
