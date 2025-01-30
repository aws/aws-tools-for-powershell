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
using Amazon.CloudHSMV2;
using Amazon.CloudHSMV2.Model;

namespace Amazon.PowerShell.Cmdlets.HSM2
{
    /// <summary>
    /// Deletes the specified HSM. To specify an HSM, you can use its identifier (ID), the
    /// IP address of the HSM's elastic network interface (ENI), or the ID of the HSM's ENI.
    /// You need to specify only one of these values. To find these values, use <a>DescribeClusters</a>.
    /// 
    ///  
    /// <para><b>Cross-account use:</b> No. You cannot perform this operation on an CloudHSM hsm
    /// in a different Amazon Web Services account.
    /// </para>
    /// </summary>
    [Cmdlet("Remove", "HSM2Hsm", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS CloudHSM V2 DeleteHsm API operation.", Operation = new[] {"DeleteHsm"}, SelectReturnType = typeof(Amazon.CloudHSMV2.Model.DeleteHsmResponse))]
    [AWSCmdletOutput("System.String or Amazon.CloudHSMV2.Model.DeleteHsmResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.CloudHSMV2.Model.DeleteHsmResponse) can be returned by specifying '-Select *'."
    )]
    public partial class RemoveHSM2HsmCmdlet : AmazonCloudHSMV2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ClusterId
        /// <summary>
        /// <para>
        /// <para>The identifier (ID) of the cluster that contains the HSM that you are deleting.</para>
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
        public System.String ClusterId { get; set; }
        #endregion
        
        #region Parameter EniId
        /// <summary>
        /// <para>
        /// <para>The identifier (ID) of the elastic network interface (ENI) of the HSM that you are
        /// deleting.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EniId { get; set; }
        #endregion
        
        #region Parameter EniIp
        /// <summary>
        /// <para>
        /// <para>The IP address of the elastic network interface (ENI) of the HSM that you are deleting.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EniIp { get; set; }
        #endregion
        
        #region Parameter HsmId
        /// <summary>
        /// <para>
        /// <para>The identifier (ID) of the HSM that you are deleting.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String HsmId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'HsmId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CloudHSMV2.Model.DeleteHsmResponse).
        /// Specifying the name of a property of type Amazon.CloudHSMV2.Model.DeleteHsmResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "HsmId";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the HsmId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^HsmId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^HsmId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.HsmId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-HSM2Hsm (DeleteHsm)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CloudHSMV2.Model.DeleteHsmResponse, RemoveHSM2HsmCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.HsmId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ClusterId = this.ClusterId;
            #if MODULAR
            if (this.ClusterId == null && ParameterWasBound(nameof(this.ClusterId)))
            {
                WriteWarning("You are passing $null as a value for parameter ClusterId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.EniId = this.EniId;
            context.EniIp = this.EniIp;
            context.HsmId = this.HsmId;
            
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
            var request = new Amazon.CloudHSMV2.Model.DeleteHsmRequest();
            
            if (cmdletContext.ClusterId != null)
            {
                request.ClusterId = cmdletContext.ClusterId;
            }
            if (cmdletContext.EniId != null)
            {
                request.EniId = cmdletContext.EniId;
            }
            if (cmdletContext.EniIp != null)
            {
                request.EniIp = cmdletContext.EniIp;
            }
            if (cmdletContext.HsmId != null)
            {
                request.HsmId = cmdletContext.HsmId;
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
        
        private Amazon.CloudHSMV2.Model.DeleteHsmResponse CallAWSServiceOperation(IAmazonCloudHSMV2 client, Amazon.CloudHSMV2.Model.DeleteHsmRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS CloudHSM V2", "DeleteHsm");
            try
            {
                #if DESKTOP
                return client.DeleteHsm(request);
                #elif CORECLR
                return client.DeleteHsmAsync(request).GetAwaiter().GetResult();
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
            public System.String ClusterId { get; set; }
            public System.String EniId { get; set; }
            public System.String EniIp { get; set; }
            public System.String HsmId { get; set; }
            public System.Func<Amazon.CloudHSMV2.Model.DeleteHsmResponse, RemoveHSM2HsmCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.HsmId;
        }
        
    }
}
