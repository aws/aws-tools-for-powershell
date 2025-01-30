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
using Amazon.IoTWireless;
using Amazon.IoTWireless.Model;

namespace Amazon.PowerShell.Cmdlets.IOTW
{
    /// <summary>
    /// Updates properties of a partner account.
    /// </summary>
    [Cmdlet("Update", "IOTWPartnerAccount", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS IoT Wireless UpdatePartnerAccount API operation.", Operation = new[] {"UpdatePartnerAccount"}, SelectReturnType = typeof(Amazon.IoTWireless.Model.UpdatePartnerAccountResponse))]
    [AWSCmdletOutput("None or Amazon.IoTWireless.Model.UpdatePartnerAccountResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.IoTWireless.Model.UpdatePartnerAccountResponse) be returned by specifying '-Select *'."
    )]
    public partial class UpdateIOTWPartnerAccountCmdlet : AmazonIoTWirelessClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Sidewalk_AppServerPrivateKey
        /// <summary>
        /// <para>
        /// <para>The new Sidewalk application server private key.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Sidewalk_AppServerPrivateKey { get; set; }
        #endregion
        
        #region Parameter PartnerAccountId
        /// <summary>
        /// <para>
        /// <para>The ID of the partner account to update.</para>
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
        public System.String PartnerAccountId { get; set; }
        #endregion
        
        #region Parameter PartnerType
        /// <summary>
        /// <para>
        /// <para>The partner type.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.IoTWireless.PartnerType")]
        public Amazon.IoTWireless.PartnerType PartnerType { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IoTWireless.Model.UpdatePartnerAccountResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the PartnerAccountId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^PartnerAccountId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^PartnerAccountId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.PartnerAccountId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-IOTWPartnerAccount (UpdatePartnerAccount)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.IoTWireless.Model.UpdatePartnerAccountResponse, UpdateIOTWPartnerAccountCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.PartnerAccountId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.PartnerAccountId = this.PartnerAccountId;
            #if MODULAR
            if (this.PartnerAccountId == null && ParameterWasBound(nameof(this.PartnerAccountId)))
            {
                WriteWarning("You are passing $null as a value for parameter PartnerAccountId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.PartnerType = this.PartnerType;
            #if MODULAR
            if (this.PartnerType == null && ParameterWasBound(nameof(this.PartnerType)))
            {
                WriteWarning("You are passing $null as a value for parameter PartnerType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Sidewalk_AppServerPrivateKey = this.Sidewalk_AppServerPrivateKey;
            
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
            var request = new Amazon.IoTWireless.Model.UpdatePartnerAccountRequest();
            
            if (cmdletContext.PartnerAccountId != null)
            {
                request.PartnerAccountId = cmdletContext.PartnerAccountId;
            }
            if (cmdletContext.PartnerType != null)
            {
                request.PartnerType = cmdletContext.PartnerType;
            }
            
             // populate Sidewalk
            var requestSidewalkIsNull = true;
            request.Sidewalk = new Amazon.IoTWireless.Model.SidewalkUpdateAccount();
            System.String requestSidewalk_sidewalk_AppServerPrivateKey = null;
            if (cmdletContext.Sidewalk_AppServerPrivateKey != null)
            {
                requestSidewalk_sidewalk_AppServerPrivateKey = cmdletContext.Sidewalk_AppServerPrivateKey;
            }
            if (requestSidewalk_sidewalk_AppServerPrivateKey != null)
            {
                request.Sidewalk.AppServerPrivateKey = requestSidewalk_sidewalk_AppServerPrivateKey;
                requestSidewalkIsNull = false;
            }
             // determine if request.Sidewalk should be set to null
            if (requestSidewalkIsNull)
            {
                request.Sidewalk = null;
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
        
        private Amazon.IoTWireless.Model.UpdatePartnerAccountResponse CallAWSServiceOperation(IAmazonIoTWireless client, Amazon.IoTWireless.Model.UpdatePartnerAccountRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS IoT Wireless", "UpdatePartnerAccount");
            try
            {
                #if DESKTOP
                return client.UpdatePartnerAccount(request);
                #elif CORECLR
                return client.UpdatePartnerAccountAsync(request).GetAwaiter().GetResult();
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
            public System.String PartnerAccountId { get; set; }
            public Amazon.IoTWireless.PartnerType PartnerType { get; set; }
            public System.String Sidewalk_AppServerPrivateKey { get; set; }
            public System.Func<Amazon.IoTWireless.Model.UpdatePartnerAccountResponse, UpdateIOTWPartnerAccountCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
