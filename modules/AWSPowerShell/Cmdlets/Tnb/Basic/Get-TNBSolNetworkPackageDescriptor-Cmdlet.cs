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
using Amazon.Tnb;
using Amazon.Tnb.Model;

namespace Amazon.PowerShell.Cmdlets.TNB
{
    /// <summary>
    /// Gets the content of the network service descriptor.
    /// 
    ///  
    /// <para>
    /// A network service descriptor is a .yaml file in a network package that uses the TOSCA
    /// standard to describe the network functions you want to deploy and the Amazon Web Services
    /// infrastructure you want to deploy the network functions on.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "TNBSolNetworkPackageDescriptor")]
    [OutputType("Amazon.Tnb.Model.GetSolNetworkPackageDescriptorResponse")]
    [AWSCmdlet("Calls the AWS Telco Network Builder GetSolNetworkPackageDescriptor API operation.", Operation = new[] {"GetSolNetworkPackageDescriptor"}, SelectReturnType = typeof(Amazon.Tnb.Model.GetSolNetworkPackageDescriptorResponse))]
    [AWSCmdletOutput("Amazon.Tnb.Model.GetSolNetworkPackageDescriptorResponse",
        "This cmdlet returns an Amazon.Tnb.Model.GetSolNetworkPackageDescriptorResponse object containing multiple properties."
    )]
    public partial class GetTNBSolNetworkPackageDescriptorCmdlet : AmazonTnbClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter NsdInfoId
        /// <summary>
        /// <para>
        /// <para>ID of the network service descriptor in the network package.</para>
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
        public System.String NsdInfoId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Tnb.Model.GetSolNetworkPackageDescriptorResponse).
        /// Specifying the name of a property of type Amazon.Tnb.Model.GetSolNetworkPackageDescriptorResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
                context.Select = CreateSelectDelegate<Amazon.Tnb.Model.GetSolNetworkPackageDescriptorResponse, GetTNBSolNetworkPackageDescriptorCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.NsdInfoId = this.NsdInfoId;
            #if MODULAR
            if (this.NsdInfoId == null && ParameterWasBound(nameof(this.NsdInfoId)))
            {
                WriteWarning("You are passing $null as a value for parameter NsdInfoId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Tnb.Model.GetSolNetworkPackageDescriptorRequest();
            
            if (cmdletContext.NsdInfoId != null)
            {
                request.NsdInfoId = cmdletContext.NsdInfoId;
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
        
        private Amazon.Tnb.Model.GetSolNetworkPackageDescriptorResponse CallAWSServiceOperation(IAmazonTnb client, Amazon.Tnb.Model.GetSolNetworkPackageDescriptorRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Telco Network Builder", "GetSolNetworkPackageDescriptor");
            try
            {
                #if DESKTOP
                return client.GetSolNetworkPackageDescriptor(request);
                #elif CORECLR
                return client.GetSolNetworkPackageDescriptorAsync(request).GetAwaiter().GetResult();
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
            public System.String NsdInfoId { get; set; }
            public System.Func<Amazon.Tnb.Model.GetSolNetworkPackageDescriptorResponse, GetTNBSolNetworkPackageDescriptorCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
