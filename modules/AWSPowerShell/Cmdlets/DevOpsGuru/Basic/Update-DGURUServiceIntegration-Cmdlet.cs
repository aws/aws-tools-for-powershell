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
using Amazon.PowerShell.Common;
using Amazon.Runtime;
using Amazon.DevOpsGuru;
using Amazon.DevOpsGuru.Model;

namespace Amazon.PowerShell.Cmdlets.DGURU
{
    /// <summary>
    /// Enables or disables integration with a service that can be integrated with DevOps
    /// Guru. The one service that can be integrated with DevOps Guru is Amazon Web Services
    /// Systems Manager, which can be used to create an OpsItem for each generated insight.
    /// </summary>
    [Cmdlet("Update", "DGURUServiceIntegration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon DevOps Guru UpdateServiceIntegration API operation.", Operation = new[] {"UpdateServiceIntegration"}, SelectReturnType = typeof(Amazon.DevOpsGuru.Model.UpdateServiceIntegrationResponse))]
    [AWSCmdletOutput("None or Amazon.DevOpsGuru.Model.UpdateServiceIntegrationResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.DevOpsGuru.Model.UpdateServiceIntegrationResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateDGURUServiceIntegrationCmdlet : AmazonDevOpsGuruClientCmdlet, IExecutor
    {
        
        #region Parameter ServiceIntegration_OpsCenter
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public Amazon.DevOpsGuru.Model.OpsCenterIntegrationConfig ServiceIntegration_OpsCenter { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.DevOpsGuru.Model.UpdateServiceIntegrationResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ServiceIntegration_OpsCenter parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ServiceIntegration_OpsCenter' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ServiceIntegration_OpsCenter' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ServiceIntegration_OpsCenter), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-DGURUServiceIntegration (UpdateServiceIntegration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.DevOpsGuru.Model.UpdateServiceIntegrationResponse, UpdateDGURUServiceIntegrationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ServiceIntegration_OpsCenter;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ServiceIntegration_OpsCenter = this.ServiceIntegration_OpsCenter;
            
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
            var request = new Amazon.DevOpsGuru.Model.UpdateServiceIntegrationRequest();
            
            
             // populate ServiceIntegration
            var requestServiceIntegrationIsNull = true;
            request.ServiceIntegration = new Amazon.DevOpsGuru.Model.UpdateServiceIntegrationConfig();
            Amazon.DevOpsGuru.Model.OpsCenterIntegrationConfig requestServiceIntegration_serviceIntegration_OpsCenter = null;
            if (cmdletContext.ServiceIntegration_OpsCenter != null)
            {
                requestServiceIntegration_serviceIntegration_OpsCenter = cmdletContext.ServiceIntegration_OpsCenter;
            }
            if (requestServiceIntegration_serviceIntegration_OpsCenter != null)
            {
                request.ServiceIntegration.OpsCenter = requestServiceIntegration_serviceIntegration_OpsCenter;
                requestServiceIntegrationIsNull = false;
            }
             // determine if request.ServiceIntegration should be set to null
            if (requestServiceIntegrationIsNull)
            {
                request.ServiceIntegration = null;
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
        
        private Amazon.DevOpsGuru.Model.UpdateServiceIntegrationResponse CallAWSServiceOperation(IAmazonDevOpsGuru client, Amazon.DevOpsGuru.Model.UpdateServiceIntegrationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon DevOps Guru", "UpdateServiceIntegration");
            try
            {
                #if DESKTOP
                return client.UpdateServiceIntegration(request);
                #elif CORECLR
                return client.UpdateServiceIntegrationAsync(request).GetAwaiter().GetResult();
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
            public Amazon.DevOpsGuru.Model.OpsCenterIntegrationConfig ServiceIntegration_OpsCenter { get; set; }
            public System.Func<Amazon.DevOpsGuru.Model.UpdateServiceIntegrationResponse, UpdateDGURUServiceIntegrationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
