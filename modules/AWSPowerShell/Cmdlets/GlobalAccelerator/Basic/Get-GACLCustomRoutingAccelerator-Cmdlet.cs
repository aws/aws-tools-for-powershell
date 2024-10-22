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
using Amazon.GlobalAccelerator;
using Amazon.GlobalAccelerator.Model;

namespace Amazon.PowerShell.Cmdlets.GACL
{
    /// <summary>
    /// Describe a custom routing accelerator.
    /// </summary>
    [Cmdlet("Get", "GACLCustomRoutingAccelerator")]
    [OutputType("Amazon.GlobalAccelerator.Model.CustomRoutingAccelerator")]
    [AWSCmdlet("Calls the AWS Global Accelerator DescribeCustomRoutingAccelerator API operation.", Operation = new[] {"DescribeCustomRoutingAccelerator"}, SelectReturnType = typeof(Amazon.GlobalAccelerator.Model.DescribeCustomRoutingAcceleratorResponse))]
    [AWSCmdletOutput("Amazon.GlobalAccelerator.Model.CustomRoutingAccelerator or Amazon.GlobalAccelerator.Model.DescribeCustomRoutingAcceleratorResponse",
        "This cmdlet returns an Amazon.GlobalAccelerator.Model.CustomRoutingAccelerator object.",
        "The service call response (type Amazon.GlobalAccelerator.Model.DescribeCustomRoutingAcceleratorResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetGACLCustomRoutingAcceleratorCmdlet : AmazonGlobalAcceleratorClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AcceleratorArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the accelerator to describe.</para>
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
        public System.String AcceleratorArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Accelerator'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.GlobalAccelerator.Model.DescribeCustomRoutingAcceleratorResponse).
        /// Specifying the name of a property of type Amazon.GlobalAccelerator.Model.DescribeCustomRoutingAcceleratorResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Accelerator";
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.GlobalAccelerator.Model.DescribeCustomRoutingAcceleratorResponse, GetGACLCustomRoutingAcceleratorCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AcceleratorArn = this.AcceleratorArn;
            #if MODULAR
            if (this.AcceleratorArn == null && ParameterWasBound(nameof(this.AcceleratorArn)))
            {
                WriteWarning("You are passing $null as a value for parameter AcceleratorArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.GlobalAccelerator.Model.DescribeCustomRoutingAcceleratorRequest();
            
            if (cmdletContext.AcceleratorArn != null)
            {
                request.AcceleratorArn = cmdletContext.AcceleratorArn;
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
        
        private Amazon.GlobalAccelerator.Model.DescribeCustomRoutingAcceleratorResponse CallAWSServiceOperation(IAmazonGlobalAccelerator client, Amazon.GlobalAccelerator.Model.DescribeCustomRoutingAcceleratorRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Global Accelerator", "DescribeCustomRoutingAccelerator");
            try
            {
                #if DESKTOP
                return client.DescribeCustomRoutingAccelerator(request);
                #elif CORECLR
                return client.DescribeCustomRoutingAcceleratorAsync(request).GetAwaiter().GetResult();
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
            public System.String AcceleratorArn { get; set; }
            public System.Func<Amazon.GlobalAccelerator.Model.DescribeCustomRoutingAcceleratorResponse, GetGACLCustomRoutingAcceleratorCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Accelerator;
        }
        
    }
}
