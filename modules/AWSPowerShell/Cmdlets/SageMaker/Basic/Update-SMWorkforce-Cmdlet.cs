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
using Amazon.SageMaker;
using Amazon.SageMaker.Model;

namespace Amazon.PowerShell.Cmdlets.SM
{
    /// <summary>
    /// Restricts access to tasks assigned to workers in the specified workforce to those
    /// within specific ranges of IP addresses. You specify allowed IP addresses by creating
    /// a list of up to four <a href="https://docs.aws.amazon.com/vpc/latest/userguide/VPC_Subnets.html">CIDRs</a>.
    /// 
    ///  
    /// <para>
    /// By default, a workforce isn't restricted to specific IP addresses. If you specify
    /// a range of IP addresses, workers who attempt to access tasks using any IP address
    /// outside the specified range are denied access and get a <code>Not Found</code> error
    /// message on the worker portal. After restricting access with this operation, you can
    /// see the allowed IP values for a private workforce with the operation.
    /// </para><important><para>
    /// This operation applies only to private workforces.
    /// </para></important>
    /// </summary>
    [Cmdlet("Update", "SMWorkforce", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.SageMaker.Model.Workforce")]
    [AWSCmdlet("Calls the Amazon SageMaker Service UpdateWorkforce API operation.", Operation = new[] {"UpdateWorkforce"}, SelectReturnType = typeof(Amazon.SageMaker.Model.UpdateWorkforceResponse))]
    [AWSCmdletOutput("Amazon.SageMaker.Model.Workforce or Amazon.SageMaker.Model.UpdateWorkforceResponse",
        "This cmdlet returns an Amazon.SageMaker.Model.Workforce object.",
        "The service call response (type Amazon.SageMaker.Model.UpdateWorkforceResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateSMWorkforceCmdlet : AmazonSageMakerClientCmdlet, IExecutor
    {
        
        #region Parameter SourceIpConfig_Cidr
        /// <summary>
        /// <para>
        /// <para>A list of one to four <a href="https://docs.aws.amazon.com/vpc/latest/userguide/VPC_Subnets.html">Classless
        /// Inter-Domain Routing</a> (CIDR) values.</para><para>Maximum: Four CIDR values</para><note><para>The following Length Constraints apply to individual CIDR values in the CIDR value
        /// list.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SourceIpConfig_Cidrs")]
        public System.String[] SourceIpConfig_Cidr { get; set; }
        #endregion
        
        #region Parameter WorkforceName
        /// <summary>
        /// <para>
        /// <para>The name of the private workforce whose access you want to restrict. <code>WorkforceName</code>
        /// is automatically set to <code>default</code> when a workforce is created and cannot
        /// be modified. </para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String WorkforceName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Workforce'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SageMaker.Model.UpdateWorkforceResponse).
        /// Specifying the name of a property of type Amazon.SageMaker.Model.UpdateWorkforceResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Workforce";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the WorkforceName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^WorkforceName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^WorkforceName' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.WorkforceName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-SMWorkforce (UpdateWorkforce)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SageMaker.Model.UpdateWorkforceResponse, UpdateSMWorkforceCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.WorkforceName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.SourceIpConfig_Cidr != null)
            {
                context.SourceIpConfig_Cidr = new List<System.String>(this.SourceIpConfig_Cidr);
            }
            context.WorkforceName = this.WorkforceName;
            #if MODULAR
            if (this.WorkforceName == null && ParameterWasBound(nameof(this.WorkforceName)))
            {
                WriteWarning("You are passing $null as a value for parameter WorkforceName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.SageMaker.Model.UpdateWorkforceRequest();
            
            
             // populate SourceIpConfig
            var requestSourceIpConfigIsNull = true;
            request.SourceIpConfig = new Amazon.SageMaker.Model.SourceIpConfig();
            List<System.String> requestSourceIpConfig_sourceIpConfig_Cidr = null;
            if (cmdletContext.SourceIpConfig_Cidr != null)
            {
                requestSourceIpConfig_sourceIpConfig_Cidr = cmdletContext.SourceIpConfig_Cidr;
            }
            if (requestSourceIpConfig_sourceIpConfig_Cidr != null)
            {
                request.SourceIpConfig.Cidrs = requestSourceIpConfig_sourceIpConfig_Cidr;
                requestSourceIpConfigIsNull = false;
            }
             // determine if request.SourceIpConfig should be set to null
            if (requestSourceIpConfigIsNull)
            {
                request.SourceIpConfig = null;
            }
            if (cmdletContext.WorkforceName != null)
            {
                request.WorkforceName = cmdletContext.WorkforceName;
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
        
        private Amazon.SageMaker.Model.UpdateWorkforceResponse CallAWSServiceOperation(IAmazonSageMaker client, Amazon.SageMaker.Model.UpdateWorkforceRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon SageMaker Service", "UpdateWorkforce");
            try
            {
                #if DESKTOP
                return client.UpdateWorkforce(request);
                #elif CORECLR
                return client.UpdateWorkforceAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> SourceIpConfig_Cidr { get; set; }
            public System.String WorkforceName { get; set; }
            public System.Func<Amazon.SageMaker.Model.UpdateWorkforceResponse, UpdateSMWorkforceCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Workforce;
        }
        
    }
}
