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
using Amazon.EC2;
using Amazon.EC2.Model;

namespace Amazon.PowerShell.Cmdlets.EC2
{
    /// <summary>
    /// Describes the default credit option for CPU usage of a burstable performance instance
    /// family.
    /// 
    ///  
    /// <para>
    /// For more information, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/burstable-performance-instances.html">Burstable
    /// performance instances</a> in the <i>Amazon EC2 User Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "EC2DefaultCreditSpecification")]
    [OutputType("Amazon.EC2.Model.InstanceFamilyCreditSpecification")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) GetDefaultCreditSpecification API operation.", Operation = new[] {"GetDefaultCreditSpecification"}, SelectReturnType = typeof(Amazon.EC2.Model.GetDefaultCreditSpecificationResponse))]
    [AWSCmdletOutput("Amazon.EC2.Model.InstanceFamilyCreditSpecification or Amazon.EC2.Model.GetDefaultCreditSpecificationResponse",
        "This cmdlet returns an Amazon.EC2.Model.InstanceFamilyCreditSpecification object.",
        "The service call response (type Amazon.EC2.Model.GetDefaultCreditSpecificationResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetEC2DefaultCreditSpecificationCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter InstanceFamily
        /// <summary>
        /// <para>
        /// <para>The instance family.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.EC2.UnlimitedSupportedInstanceFamily")]
        public Amazon.EC2.UnlimitedSupportedInstanceFamily InstanceFamily { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'InstanceFamilyCreditSpecification'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.GetDefaultCreditSpecificationResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.GetDefaultCreditSpecificationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "InstanceFamilyCreditSpecification";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the InstanceFamily parameter.
        /// The -PassThru parameter is deprecated, use -Select '^InstanceFamily' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^InstanceFamily' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.GetDefaultCreditSpecificationResponse, GetEC2DefaultCreditSpecificationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.InstanceFamily;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.InstanceFamily = this.InstanceFamily;
            #if MODULAR
            if (this.InstanceFamily == null && ParameterWasBound(nameof(this.InstanceFamily)))
            {
                WriteWarning("You are passing $null as a value for parameter InstanceFamily which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.EC2.Model.GetDefaultCreditSpecificationRequest();
            
            if (cmdletContext.InstanceFamily != null)
            {
                request.InstanceFamily = cmdletContext.InstanceFamily;
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
        
        private Amazon.EC2.Model.GetDefaultCreditSpecificationResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.GetDefaultCreditSpecificationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "GetDefaultCreditSpecification");
            try
            {
                #if DESKTOP
                return client.GetDefaultCreditSpecification(request);
                #elif CORECLR
                return client.GetDefaultCreditSpecificationAsync(request).GetAwaiter().GetResult();
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
            public Amazon.EC2.UnlimitedSupportedInstanceFamily InstanceFamily { get; set; }
            public System.Func<Amazon.EC2.Model.GetDefaultCreditSpecificationResponse, GetEC2DefaultCreditSpecificationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.InstanceFamilyCreditSpecification;
        }
        
    }
}
