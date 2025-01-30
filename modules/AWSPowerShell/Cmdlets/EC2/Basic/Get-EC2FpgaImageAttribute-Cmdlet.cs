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
    /// Describes the specified attribute of the specified Amazon FPGA Image (AFI).
    /// </summary>
    [Cmdlet("Get", "EC2FpgaImageAttribute")]
    [OutputType("Amazon.EC2.Model.FpgaImageAttribute")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) DescribeFpgaImageAttribute API operation.", Operation = new[] {"DescribeFpgaImageAttribute"}, SelectReturnType = typeof(Amazon.EC2.Model.DescribeFpgaImageAttributeResponse))]
    [AWSCmdletOutput("Amazon.EC2.Model.FpgaImageAttribute or Amazon.EC2.Model.DescribeFpgaImageAttributeResponse",
        "This cmdlet returns an Amazon.EC2.Model.FpgaImageAttribute object.",
        "The service call response (type Amazon.EC2.Model.DescribeFpgaImageAttributeResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetEC2FpgaImageAttributeCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Attribute
        /// <summary>
        /// <para>
        /// <para>The AFI attribute.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.EC2.FpgaImageAttributeName")]
        public Amazon.EC2.FpgaImageAttributeName Attribute { get; set; }
        #endregion
        
        #region Parameter FpgaImageId
        /// <summary>
        /// <para>
        /// <para>The ID of the AFI.</para>
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
        public System.String FpgaImageId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'FpgaImageAttribute'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.DescribeFpgaImageAttributeResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.DescribeFpgaImageAttributeResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "FpgaImageAttribute";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Attribute parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Attribute' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Attribute' instead. This parameter will be removed in a future version.")]
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
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.DescribeFpgaImageAttributeResponse, GetEC2FpgaImageAttributeCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Attribute;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.Attribute = this.Attribute;
            #if MODULAR
            if (this.Attribute == null && ParameterWasBound(nameof(this.Attribute)))
            {
                WriteWarning("You are passing $null as a value for parameter Attribute which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.FpgaImageId = this.FpgaImageId;
            #if MODULAR
            if (this.FpgaImageId == null && ParameterWasBound(nameof(this.FpgaImageId)))
            {
                WriteWarning("You are passing $null as a value for parameter FpgaImageId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.EC2.Model.DescribeFpgaImageAttributeRequest();
            
            if (cmdletContext.Attribute != null)
            {
                request.Attribute = cmdletContext.Attribute;
            }
            if (cmdletContext.FpgaImageId != null)
            {
                request.FpgaImageId = cmdletContext.FpgaImageId;
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
        
        private Amazon.EC2.Model.DescribeFpgaImageAttributeResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.DescribeFpgaImageAttributeRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "DescribeFpgaImageAttribute");
            try
            {
                #if DESKTOP
                return client.DescribeFpgaImageAttribute(request);
                #elif CORECLR
                return client.DescribeFpgaImageAttributeAsync(request).GetAwaiter().GetResult();
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
            public Amazon.EC2.FpgaImageAttributeName Attribute { get; set; }
            public System.String FpgaImageId { get; set; }
            public System.Func<Amazon.EC2.Model.DescribeFpgaImageAttributeResponse, GetEC2FpgaImageAttributeCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.FpgaImageAttribute;
        }
        
    }
}
