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
using System.Threading;
using Amazon.CloudHSM;
using Amazon.CloudHSM.Model;

namespace Amazon.PowerShell.Cmdlets.HSM
{
    /// <summary>
    /// This is documentation for <b>AWS CloudHSM Classic</b>. For more information, see <a href="http://aws.amazon.com/cloudhsm/faqs-classic/">AWS CloudHSM Classic FAQs</a>,
    /// the <a href="https://docs.aws.amazon.com/cloudhsm/classic/userguide/">AWS CloudHSM
    /// Classic User Guide</a>, and the <a href="https://docs.aws.amazon.com/cloudhsm/classic/APIReference/">AWS
    /// CloudHSM Classic API Reference</a>.
    /// 
    ///  
    /// <para><b>For information about the current version of AWS CloudHSM</b>, see <a href="http://aws.amazon.com/cloudhsm/">AWS
    /// CloudHSM</a>, the <a href="https://docs.aws.amazon.com/cloudhsm/latest/userguide/">AWS
    /// CloudHSM User Guide</a>, and the <a href="https://docs.aws.amazon.com/cloudhsm/latest/APIReference/">AWS
    /// CloudHSM API Reference</a>.
    /// </para><para>
    /// Creates an uninitialized HSM instance.
    /// </para><para>
    /// There is an upfront fee charged for each HSM instance that you create with the <c>CreateHsm</c>
    /// operation. If you accidentally provision an HSM and want to request a refund, delete
    /// the instance using the <a>DeleteHsm</a> operation, go to the <a href="https://console.aws.amazon.com/support/home">AWS
    /// Support Center</a>, create a new case, and select <b>Account and Billing Support</b>.
    /// </para><important><para>
    /// It can take up to 20 minutes to create and provision an HSM. You can monitor the status
    /// of the HSM with the <a>DescribeHsm</a> operation. The HSM is ready to be initialized
    /// when the status changes to <c>RUNNING</c>.
    /// </para></important><br/><br/>This operation is deprecated.
    /// </summary>
    [Cmdlet("New", "HSMItem", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS CloudHSM CreateHsm API operation.", Operation = new[] {"CreateHsm"}, SelectReturnType = typeof(Amazon.CloudHSM.Model.CreateHsmResponse))]
    [AWSCmdletOutput("System.String or Amazon.CloudHSM.Model.CreateHsmResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.CloudHSM.Model.CreateHsmResponse) can be returned by specifying '-Select *'."
    )]
    [System.ObsoleteAttribute("This API is deprecated.")]
    public partial class NewHSMItemCmdlet : AmazonCloudHSMClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter EniIp
        /// <summary>
        /// <para>
        /// <para>The IP address to assign to the HSM's ENI.</para><para>If an IP address is not specified, an IP address will be randomly chosen from the
        /// CIDR range of the subnet.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EniIp { get; set; }
        #endregion
        
        #region Parameter ExternalId
        /// <summary>
        /// <para>
        /// <para>The external ID from <c>IamRoleArn</c>, if present.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ExternalId { get; set; }
        #endregion
        
        #region Parameter IamRoleArn
        /// <summary>
        /// <para>
        /// <para>The ARN of an IAM role to enable the AWS CloudHSM service to allocate an ENI on your
        /// behalf.</para>
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
        public System.String IamRoleArn { get; set; }
        #endregion
        
        #region Parameter SshKey
        /// <summary>
        /// <para>
        /// <para>The SSH public key to install on the HSM.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String SshKey { get; set; }
        #endregion
        
        #region Parameter SubnetId
        /// <summary>
        /// <para>
        /// <para>The identifier of the subnet in your VPC in which to place the HSM.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String SubnetId { get; set; }
        #endregion
        
        #region Parameter SubscriptionType
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.CloudHSM.SubscriptionType")]
        public Amazon.CloudHSM.SubscriptionType SubscriptionType { get; set; }
        #endregion
        
        #region Parameter SyslogIp
        /// <summary>
        /// <para>
        /// <para>The IP address for the syslog monitoring server. The AWS CloudHSM service only supports
        /// one syslog monitoring server.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SyslogIp { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A user-defined token to ensure idempotence. Subsequent calls to this operation with
        /// the same token will be ignored.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'HsmArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CloudHSM.Model.CreateHsmResponse).
        /// Specifying the name of a property of type Amazon.CloudHSM.Model.CreateHsmResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "HsmArn";
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
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-HSMItem (CreateHsm)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CloudHSM.Model.CreateHsmResponse, NewHSMItemCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientToken = this.ClientToken;
            context.EniIp = this.EniIp;
            context.ExternalId = this.ExternalId;
            context.IamRoleArn = this.IamRoleArn;
            #if MODULAR
            if (this.IamRoleArn == null && ParameterWasBound(nameof(this.IamRoleArn)))
            {
                WriteWarning("You are passing $null as a value for parameter IamRoleArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SshKey = this.SshKey;
            #if MODULAR
            if (this.SshKey == null && ParameterWasBound(nameof(this.SshKey)))
            {
                WriteWarning("You are passing $null as a value for parameter SshKey which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SubnetId = this.SubnetId;
            #if MODULAR
            if (this.SubnetId == null && ParameterWasBound(nameof(this.SubnetId)))
            {
                WriteWarning("You are passing $null as a value for parameter SubnetId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SubscriptionType = this.SubscriptionType;
            #if MODULAR
            if (this.SubscriptionType == null && ParameterWasBound(nameof(this.SubscriptionType)))
            {
                WriteWarning("You are passing $null as a value for parameter SubscriptionType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SyslogIp = this.SyslogIp;
            
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
            var request = new Amazon.CloudHSM.Model.CreateHsmRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.EniIp != null)
            {
                request.EniIp = cmdletContext.EniIp;
            }
            if (cmdletContext.ExternalId != null)
            {
                request.ExternalId = cmdletContext.ExternalId;
            }
            if (cmdletContext.IamRoleArn != null)
            {
                request.IamRoleArn = cmdletContext.IamRoleArn;
            }
            if (cmdletContext.SshKey != null)
            {
                request.SshKey = cmdletContext.SshKey;
            }
            if (cmdletContext.SubnetId != null)
            {
                request.SubnetId = cmdletContext.SubnetId;
            }
            if (cmdletContext.SubscriptionType != null)
            {
                request.SubscriptionType = cmdletContext.SubscriptionType;
            }
            if (cmdletContext.SyslogIp != null)
            {
                request.SyslogIp = cmdletContext.SyslogIp;
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
        
        private Amazon.CloudHSM.Model.CreateHsmResponse CallAWSServiceOperation(IAmazonCloudHSM client, Amazon.CloudHSM.Model.CreateHsmRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS CloudHSM", "CreateHsm");
            try
            {
                return client.CreateHsmAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ClientToken { get; set; }
            public System.String EniIp { get; set; }
            public System.String ExternalId { get; set; }
            public System.String IamRoleArn { get; set; }
            public System.String SshKey { get; set; }
            public System.String SubnetId { get; set; }
            public Amazon.CloudHSM.SubscriptionType SubscriptionType { get; set; }
            public System.String SyslogIp { get; set; }
            public System.Func<Amazon.CloudHSM.Model.CreateHsmResponse, NewHSMItemCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.HsmArn;
        }
        
    }
}
