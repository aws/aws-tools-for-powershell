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
using Amazon.ChimeSDKVoice;
using Amazon.ChimeSDKVoice.Model;

namespace Amazon.PowerShell.Cmdlets.CHMVO
{
    /// <summary>
    /// Creates an order for phone numbers to be provisioned. For numbers outside the U.S.,
    /// you must use the Amazon Chime SDK SIP media application dial-in product type.
    /// </summary>
    [Cmdlet("New", "CHMVOPhoneNumberOrder", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ChimeSDKVoice.Model.PhoneNumberOrder")]
    [AWSCmdlet("Calls the Amazon Chime SDK Voice CreatePhoneNumberOrder API operation.", Operation = new[] {"CreatePhoneNumberOrder"}, SelectReturnType = typeof(Amazon.ChimeSDKVoice.Model.CreatePhoneNumberOrderResponse))]
    [AWSCmdletOutput("Amazon.ChimeSDKVoice.Model.PhoneNumberOrder or Amazon.ChimeSDKVoice.Model.CreatePhoneNumberOrderResponse",
        "This cmdlet returns an Amazon.ChimeSDKVoice.Model.PhoneNumberOrder object.",
        "The service call response (type Amazon.ChimeSDKVoice.Model.CreatePhoneNumberOrderResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewCHMVOPhoneNumberOrderCmdlet : AmazonChimeSDKVoiceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter E164PhoneNumber
        /// <summary>
        /// <para>
        /// <para>List of phone numbers, in E.164 format.</para>
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
        [Alias("E164PhoneNumbers")]
        public System.String[] E164PhoneNumber { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>Specifies the name assigned to one or more phone numbers.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter ProductType
        /// <summary>
        /// <para>
        /// <para>The phone number product type.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.ChimeSDKVoice.PhoneNumberProductType")]
        public Amazon.ChimeSDKVoice.PhoneNumberProductType ProductType { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'PhoneNumberOrder'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ChimeSDKVoice.Model.CreatePhoneNumberOrderResponse).
        /// Specifying the name of a property of type Amazon.ChimeSDKVoice.Model.CreatePhoneNumberOrderResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "PhoneNumberOrder";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ProductType), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-CHMVOPhoneNumberOrder (CreatePhoneNumberOrder)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ChimeSDKVoice.Model.CreatePhoneNumberOrderResponse, NewCHMVOPhoneNumberOrderCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.E164PhoneNumber != null)
            {
                context.E164PhoneNumber = new List<System.String>(this.E164PhoneNumber);
            }
            #if MODULAR
            if (this.E164PhoneNumber == null && ParameterWasBound(nameof(this.E164PhoneNumber)))
            {
                WriteWarning("You are passing $null as a value for parameter E164PhoneNumber which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Name = this.Name;
            context.ProductType = this.ProductType;
            #if MODULAR
            if (this.ProductType == null && ParameterWasBound(nameof(this.ProductType)))
            {
                WriteWarning("You are passing $null as a value for parameter ProductType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.ChimeSDKVoice.Model.CreatePhoneNumberOrderRequest();
            
            if (cmdletContext.E164PhoneNumber != null)
            {
                request.E164PhoneNumbers = cmdletContext.E164PhoneNumber;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.ProductType != null)
            {
                request.ProductType = cmdletContext.ProductType;
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
        
        private Amazon.ChimeSDKVoice.Model.CreatePhoneNumberOrderResponse CallAWSServiceOperation(IAmazonChimeSDKVoice client, Amazon.ChimeSDKVoice.Model.CreatePhoneNumberOrderRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Chime SDK Voice", "CreatePhoneNumberOrder");
            try
            {
                return client.CreatePhoneNumberOrderAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<System.String> E164PhoneNumber { get; set; }
            public System.String Name { get; set; }
            public Amazon.ChimeSDKVoice.PhoneNumberProductType ProductType { get; set; }
            public System.Func<Amazon.ChimeSDKVoice.Model.CreatePhoneNumberOrderResponse, NewCHMVOPhoneNumberOrderCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.PhoneNumberOrder;
        }
        
    }
}
