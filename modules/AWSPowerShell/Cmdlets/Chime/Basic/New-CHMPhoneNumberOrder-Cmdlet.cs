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
using Amazon.Chime;
using Amazon.Chime.Model;

namespace Amazon.PowerShell.Cmdlets.CHM
{
    /// <summary>
    /// Creates an order for phone numbers to be provisioned. Choose from Amazon Chime Business
    /// Calling and Amazon Chime Voice Connector product types. For toll-free numbers, you
    /// must use the Amazon Chime Voice Connector product type.
    /// </summary>
    [Cmdlet("New", "CHMPhoneNumberOrder", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Chime.Model.PhoneNumberOrder")]
    [AWSCmdlet("Calls the Amazon Chime CreatePhoneNumberOrder API operation.", Operation = new[] {"CreatePhoneNumberOrder"}, SelectReturnType = typeof(Amazon.Chime.Model.CreatePhoneNumberOrderResponse))]
    [AWSCmdletOutput("Amazon.Chime.Model.PhoneNumberOrder or Amazon.Chime.Model.CreatePhoneNumberOrderResponse",
        "This cmdlet returns an Amazon.Chime.Model.PhoneNumberOrder object.",
        "The service call response (type Amazon.Chime.Model.CreatePhoneNumberOrderResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewCHMPhoneNumberOrderCmdlet : AmazonChimeClientCmdlet, IExecutor
    {
        
        #region Parameter E164PhoneNumber
        /// <summary>
        /// <para>
        /// <para>List of phone numbers, in E.164 format.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("E164PhoneNumbers")]
        public System.String[] E164PhoneNumber { get; set; }
        #endregion
        
        #region Parameter ProductType
        /// <summary>
        /// <para>
        /// <para>The phone number product type.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.Chime.PhoneNumberProductType")]
        public Amazon.Chime.PhoneNumberProductType ProductType { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'PhoneNumberOrder'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Chime.Model.CreatePhoneNumberOrderResponse).
        /// Specifying the name of a property of type Amazon.Chime.Model.CreatePhoneNumberOrderResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "PhoneNumberOrder";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the E164PhoneNumber parameter.
        /// The -PassThru parameter is deprecated, use -Select '^E164PhoneNumber' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^E164PhoneNumber' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.E164PhoneNumber), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-CHMPhoneNumberOrder (CreatePhoneNumberOrder)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Chime.Model.CreatePhoneNumberOrderResponse, NewCHMPhoneNumberOrderCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.E164PhoneNumber;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
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
            var request = new Amazon.Chime.Model.CreatePhoneNumberOrderRequest();
            
            if (cmdletContext.E164PhoneNumber != null)
            {
                request.E164PhoneNumbers = cmdletContext.E164PhoneNumber;
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
        
        private Amazon.Chime.Model.CreatePhoneNumberOrderResponse CallAWSServiceOperation(IAmazonChime client, Amazon.Chime.Model.CreatePhoneNumberOrderRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Chime", "CreatePhoneNumberOrder");
            try
            {
                #if DESKTOP
                return client.CreatePhoneNumberOrder(request);
                #elif CORECLR
                return client.CreatePhoneNumberOrderAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> E164PhoneNumber { get; set; }
            public Amazon.Chime.PhoneNumberProductType ProductType { get; set; }
            public System.Func<Amazon.Chime.Model.CreatePhoneNumberOrderResponse, NewCHMPhoneNumberOrderCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.PhoneNumberOrder;
        }
        
    }
}
