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
    /// Modifies an HSM.
    /// </para><important><para>
    /// This operation can result in the HSM being offline for up to 15 minutes while the
    /// AWS CloudHSM service is reconfigured. If you are modifying a production HSM, you should
    /// ensure that your AWS CloudHSM service is configured for high availability, and consider
    /// executing this operation during a maintenance window.
    /// </para></important><br/><br/>This operation is deprecated.
    /// </summary>
    [Cmdlet("Edit", "HSMItem", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS CloudHSM ModifyHsm API operation.", Operation = new[] {"ModifyHsm"}, SelectReturnType = typeof(Amazon.CloudHSM.Model.ModifyHsmResponse))]
    [AWSCmdletOutput("System.String or Amazon.CloudHSM.Model.ModifyHsmResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.CloudHSM.Model.ModifyHsmResponse) can be returned by specifying '-Select *'."
    )]
    [System.ObsoleteAttribute("This API is deprecated.")]
    public partial class EditHSMItemCmdlet : AmazonCloudHSMClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter EniIp
        /// <summary>
        /// <para>
        /// <para>The new IP address for the elastic network interface (ENI) attached to the HSM.</para><para>If the HSM is moved to a different subnet, and an IP address is not specified, an
        /// IP address will be randomly chosen from the CIDR range of the new subnet.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EniIp { get; set; }
        #endregion
        
        #region Parameter ExternalId
        /// <summary>
        /// <para>
        /// <para>The new external ID.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ExternalId { get; set; }
        #endregion
        
        #region Parameter HsmArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the HSM to modify.</para>
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
        public System.String HsmArn { get; set; }
        #endregion
        
        #region Parameter IamRoleArn
        /// <summary>
        /// <para>
        /// <para>The new IAM role ARN.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String IamRoleArn { get; set; }
        #endregion
        
        #region Parameter SubnetId
        /// <summary>
        /// <para>
        /// <para>The new identifier of the subnet that the HSM is in. The new subnet must be in the
        /// same Availability Zone as the current subnet.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SubnetId { get; set; }
        #endregion
        
        #region Parameter SyslogIp
        /// <summary>
        /// <para>
        /// <para>The new IP address for the syslog monitoring server. The AWS CloudHSM service only
        /// supports one syslog monitoring server.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SyslogIp { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'HsmArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CloudHSM.Model.ModifyHsmResponse).
        /// Specifying the name of a property of type Amazon.CloudHSM.Model.ModifyHsmResponse will result in that property being returned.
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
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.HsmArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Edit-HSMItem (ModifyHsm)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CloudHSM.Model.ModifyHsmResponse, EditHSMItemCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.EniIp = this.EniIp;
            context.ExternalId = this.ExternalId;
            context.HsmArn = this.HsmArn;
            #if MODULAR
            if (this.HsmArn == null && ParameterWasBound(nameof(this.HsmArn)))
            {
                WriteWarning("You are passing $null as a value for parameter HsmArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.IamRoleArn = this.IamRoleArn;
            context.SubnetId = this.SubnetId;
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
            var request = new Amazon.CloudHSM.Model.ModifyHsmRequest();
            
            if (cmdletContext.EniIp != null)
            {
                request.EniIp = cmdletContext.EniIp;
            }
            if (cmdletContext.ExternalId != null)
            {
                request.ExternalId = cmdletContext.ExternalId;
            }
            if (cmdletContext.HsmArn != null)
            {
                request.HsmArn = cmdletContext.HsmArn;
            }
            if (cmdletContext.IamRoleArn != null)
            {
                request.IamRoleArn = cmdletContext.IamRoleArn;
            }
            if (cmdletContext.SubnetId != null)
            {
                request.SubnetId = cmdletContext.SubnetId;
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
        
        private Amazon.CloudHSM.Model.ModifyHsmResponse CallAWSServiceOperation(IAmazonCloudHSM client, Amazon.CloudHSM.Model.ModifyHsmRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS CloudHSM", "ModifyHsm");
            try
            {
                #if DESKTOP
                return client.ModifyHsm(request);
                #elif CORECLR
                return client.ModifyHsmAsync(request).GetAwaiter().GetResult();
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
            public System.String EniIp { get; set; }
            public System.String ExternalId { get; set; }
            public System.String HsmArn { get; set; }
            public System.String IamRoleArn { get; set; }
            public System.String SubnetId { get; set; }
            public System.String SyslogIp { get; set; }
            public System.Func<Amazon.CloudHSM.Model.ModifyHsmResponse, EditHSMItemCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.HsmArn;
        }
        
    }
}
