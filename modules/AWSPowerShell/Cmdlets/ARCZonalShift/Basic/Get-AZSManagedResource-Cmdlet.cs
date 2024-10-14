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
using Amazon.ARCZonalShift;
using Amazon.ARCZonalShift.Model;

namespace Amazon.PowerShell.Cmdlets.AZS
{
    /// <summary>
    /// Get information about a resource that's been registered for zonal shifts with Amazon
    /// Route 53 Application Recovery Controller in this Amazon Web Services Region. Resources
    /// that are registered for zonal shifts are managed resources in Route 53 ARC. You can
    /// start zonal shifts and configure zonal autoshift for managed resources.
    /// 
    ///  
    /// <para>
    /// At this time, you can only start a zonal shift or configure zonal autoshift for Network
    /// Load Balancers and Application Load Balancers with cross-zone load balancing turned
    /// off.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "AZSManagedResource")]
    [OutputType("Amazon.ARCZonalShift.Model.GetManagedResourceResponse")]
    [AWSCmdlet("Calls the AWS ARC - Zonal Shift GetManagedResource API operation.", Operation = new[] {"GetManagedResource"}, SelectReturnType = typeof(Amazon.ARCZonalShift.Model.GetManagedResourceResponse))]
    [AWSCmdletOutput("Amazon.ARCZonalShift.Model.GetManagedResourceResponse",
        "This cmdlet returns an Amazon.ARCZonalShift.Model.GetManagedResourceResponse object containing multiple properties."
    )]
    public partial class GetAZSManagedResourceCmdlet : AmazonARCZonalShiftClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ResourceIdentifier
        /// <summary>
        /// <para>
        /// <para>The identifier for the resource that Amazon Web Services shifts traffic for. The identifier
        /// is the Amazon Resource Name (ARN) for the resource.</para><para>At this time, supported resources are Network Load Balancers and Application Load
        /// Balancers with cross-zone load balancing turned off.</para>
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
        public System.String ResourceIdentifier { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ARCZonalShift.Model.GetManagedResourceResponse).
        /// Specifying the name of a property of type Amazon.ARCZonalShift.Model.GetManagedResourceResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ResourceIdentifier parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ResourceIdentifier' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ResourceIdentifier' instead. This parameter will be removed in a future version.")]
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
                context.Select = CreateSelectDelegate<Amazon.ARCZonalShift.Model.GetManagedResourceResponse, GetAZSManagedResourceCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ResourceIdentifier;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ResourceIdentifier = this.ResourceIdentifier;
            #if MODULAR
            if (this.ResourceIdentifier == null && ParameterWasBound(nameof(this.ResourceIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter ResourceIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.ARCZonalShift.Model.GetManagedResourceRequest();
            
            if (cmdletContext.ResourceIdentifier != null)
            {
                request.ResourceIdentifier = cmdletContext.ResourceIdentifier;
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
        
        private Amazon.ARCZonalShift.Model.GetManagedResourceResponse CallAWSServiceOperation(IAmazonARCZonalShift client, Amazon.ARCZonalShift.Model.GetManagedResourceRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS ARC - Zonal Shift", "GetManagedResource");
            try
            {
                #if DESKTOP
                return client.GetManagedResource(request);
                #elif CORECLR
                return client.GetManagedResourceAsync(request).GetAwaiter().GetResult();
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
            public System.String ResourceIdentifier { get; set; }
            public System.Func<Amazon.ARCZonalShift.Model.GetManagedResourceResponse, GetAZSManagedResourceCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
