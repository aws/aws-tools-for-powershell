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
using Amazon.Drs;
using Amazon.Drs.Model;

namespace Amazon.PowerShell.Cmdlets.EDRS
{
    /// <summary>
    /// Deploy VPC for the specified Source Network and modify launch templates to use this
    /// network. The VPC will be deployed using a dedicated CloudFormation stack.
    /// </summary>
    [Cmdlet("Start", "EDRSSourceNetworkRecovery", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Drs.Model.Job")]
    [AWSCmdlet("Calls the Elastic Disaster Recovery Service StartSourceNetworkRecovery API operation.", Operation = new[] {"StartSourceNetworkRecovery"}, SelectReturnType = typeof(Amazon.Drs.Model.StartSourceNetworkRecoveryResponse))]
    [AWSCmdletOutput("Amazon.Drs.Model.Job or Amazon.Drs.Model.StartSourceNetworkRecoveryResponse",
        "This cmdlet returns an Amazon.Drs.Model.Job object.",
        "The service call response (type Amazon.Drs.Model.StartSourceNetworkRecoveryResponse) can be returned by specifying '-Select *'."
    )]
    public partial class StartEDRSSourceNetworkRecoveryCmdlet : AmazonDrsClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsSensitiveResponse { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter DeployAsNew
        /// <summary>
        /// <para>
        /// <para>Don't update existing CloudFormation Stack, recover the network using a new stack.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.Boolean? DeployAsNew { get; set; }
        #endregion
        
        #region Parameter SourceNetwork
        /// <summary>
        /// <para>
        /// <para>The Source Networks that we want to start a Recovery Job for.</para>
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
        [Alias("SourceNetworks")]
        public Amazon.Drs.Model.StartSourceNetworkRecoveryRequestNetworkEntry[] SourceNetwork { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The tags to be associated with the Source Network recovery Job.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Job'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Drs.Model.StartSourceNetworkRecoveryResponse).
        /// Specifying the name of a property of type Amazon.Drs.Model.StartSourceNetworkRecoveryResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Job";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the DeployAsNew parameter.
        /// The -PassThru parameter is deprecated, use -Select '^DeployAsNew' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^DeployAsNew' instead. This parameter will be removed in a future version.")]
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.DeployAsNew), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-EDRSSourceNetworkRecovery (StartSourceNetworkRecovery)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Drs.Model.StartSourceNetworkRecoveryResponse, StartEDRSSourceNetworkRecoveryCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.DeployAsNew;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.DeployAsNew = this.DeployAsNew;
            if (this.SourceNetwork != null)
            {
                context.SourceNetwork = new List<Amazon.Drs.Model.StartSourceNetworkRecoveryRequestNetworkEntry>(this.SourceNetwork);
            }
            #if MODULAR
            if (this.SourceNetwork == null && ParameterWasBound(nameof(this.SourceNetwork)))
            {
                WriteWarning("You are passing $null as a value for parameter SourceNetwork which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (System.String)(this.Tag[hashKey]));
                }
            }
            
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
            var request = new Amazon.Drs.Model.StartSourceNetworkRecoveryRequest();
            
            if (cmdletContext.DeployAsNew != null)
            {
                request.DeployAsNew = cmdletContext.DeployAsNew.Value;
            }
            if (cmdletContext.SourceNetwork != null)
            {
                request.SourceNetworks = cmdletContext.SourceNetwork;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
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
        
        private Amazon.Drs.Model.StartSourceNetworkRecoveryResponse CallAWSServiceOperation(IAmazonDrs client, Amazon.Drs.Model.StartSourceNetworkRecoveryRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Elastic Disaster Recovery Service", "StartSourceNetworkRecovery");
            try
            {
                #if DESKTOP
                return client.StartSourceNetworkRecovery(request);
                #elif CORECLR
                return client.StartSourceNetworkRecoveryAsync(request).GetAwaiter().GetResult();
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
            public System.Boolean? DeployAsNew { get; set; }
            public List<Amazon.Drs.Model.StartSourceNetworkRecoveryRequestNetworkEntry> SourceNetwork { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.Drs.Model.StartSourceNetworkRecoveryResponse, StartEDRSSourceNetworkRecoveryCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Job;
        }
        
    }
}
