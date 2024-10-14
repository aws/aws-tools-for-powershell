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
using Amazon.CloudFront;
using Amazon.CloudFront.Model;

namespace Amazon.PowerShell.Cmdlets.CF
{
    /// <summary>
    /// Create a new invalidation. For more information, see <a href="https://docs.aws.amazon.com/AmazonCloudFront/latest/DeveloperGuide/Invalidation.html">Invalidating
    /// files</a> in the <i>Amazon CloudFront Developer Guide</i>.
    /// </summary>
    [Cmdlet("New", "CFInvalidation", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CloudFront.Model.CreateInvalidationResponse")]
    [AWSCmdlet("Calls the Amazon CloudFront CreateInvalidation API operation.", Operation = new[] {"CreateInvalidation"}, SelectReturnType = typeof(Amazon.CloudFront.Model.CreateInvalidationResponse))]
    [AWSCmdletOutput("Amazon.CloudFront.Model.CreateInvalidationResponse",
        "This cmdlet returns an Amazon.CloudFront.Model.CreateInvalidationResponse object containing multiple properties."
    )]
    public partial class NewCFInvalidationCmdlet : AmazonCloudFrontClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter InvalidationBatch_CallerReference
        /// <summary>
        /// <para>
        /// <para>A value that you specify to uniquely identify an invalidation request. CloudFront
        /// uses the value to prevent you from accidentally resubmitting an identical request.
        /// Whenever you create a new invalidation request, you must specify a new value for <c>CallerReference</c>
        /// and change other values in the request as applicable. One way to ensure that the value
        /// of <c>CallerReference</c> is unique is to use a <c>timestamp</c>, for example, <c>20120301090000</c>.</para><para>If you make a second invalidation request with the same value for <c>CallerReference</c>,
        /// and if the rest of the request is the same, CloudFront doesn't create a new invalidation
        /// request. Instead, CloudFront returns information about the invalidation request that
        /// you previously created with the same <c>CallerReference</c>.</para><para>If <c>CallerReference</c> is a value you already sent in a previous invalidation batch
        /// request but the content of any <c>Path</c> is different from the original request,
        /// CloudFront returns an <c>InvalidationBatchAlreadyExists</c> error.</para>
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
        public System.String InvalidationBatch_CallerReference { get; set; }
        #endregion
        
        #region Parameter DistributionId
        /// <summary>
        /// <para>
        /// <para>The distribution's id.</para>
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
        public System.String DistributionId { get; set; }
        #endregion
        
        #region Parameter Paths_Item
        /// <summary>
        /// <para>
        /// <para>A complex type that contains a list of the paths that you want to invalidate.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InvalidationBatch_Paths_Items")]
        public System.String[] Paths_Item { get; set; }
        #endregion
        
        #region Parameter Paths_Quantity
        /// <summary>
        /// <para>
        /// <para>The number of invalidation paths specified for the objects that you want to invalidate.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("InvalidationBatch_Paths_Quantity")]
        public System.Int32? Paths_Quantity { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CloudFront.Model.CreateInvalidationResponse).
        /// Specifying the name of a property of type Amazon.CloudFront.Model.CreateInvalidationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the DistributionId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^DistributionId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^DistributionId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.DistributionId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-CFInvalidation (CreateInvalidation)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CloudFront.Model.CreateInvalidationResponse, NewCFInvalidationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.DistributionId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.DistributionId = this.DistributionId;
            #if MODULAR
            if (this.DistributionId == null && ParameterWasBound(nameof(this.DistributionId)))
            {
                WriteWarning("You are passing $null as a value for parameter DistributionId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.InvalidationBatch_CallerReference = this.InvalidationBatch_CallerReference;
            #if MODULAR
            if (this.InvalidationBatch_CallerReference == null && ParameterWasBound(nameof(this.InvalidationBatch_CallerReference)))
            {
                WriteWarning("You are passing $null as a value for parameter InvalidationBatch_CallerReference which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Paths_Item != null)
            {
                context.Paths_Item = new List<System.String>(this.Paths_Item);
            }
            context.Paths_Quantity = this.Paths_Quantity;
            #if MODULAR
            if (this.Paths_Quantity == null && ParameterWasBound(nameof(this.Paths_Quantity)))
            {
                WriteWarning("You are passing $null as a value for parameter Paths_Quantity which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.CloudFront.Model.CreateInvalidationRequest();
            
            if (cmdletContext.DistributionId != null)
            {
                request.DistributionId = cmdletContext.DistributionId;
            }
            
             // populate InvalidationBatch
            var requestInvalidationBatchIsNull = true;
            request.InvalidationBatch = new Amazon.CloudFront.Model.InvalidationBatch();
            System.String requestInvalidationBatch_invalidationBatch_CallerReference = null;
            if (cmdletContext.InvalidationBatch_CallerReference != null)
            {
                requestInvalidationBatch_invalidationBatch_CallerReference = cmdletContext.InvalidationBatch_CallerReference;
            }
            if (requestInvalidationBatch_invalidationBatch_CallerReference != null)
            {
                request.InvalidationBatch.CallerReference = requestInvalidationBatch_invalidationBatch_CallerReference;
                requestInvalidationBatchIsNull = false;
            }
            Amazon.CloudFront.Model.Paths requestInvalidationBatch_invalidationBatch_Paths = null;
            
             // populate Paths
            var requestInvalidationBatch_invalidationBatch_PathsIsNull = true;
            requestInvalidationBatch_invalidationBatch_Paths = new Amazon.CloudFront.Model.Paths();
            List<System.String> requestInvalidationBatch_invalidationBatch_Paths_paths_Item = null;
            if (cmdletContext.Paths_Item != null)
            {
                requestInvalidationBatch_invalidationBatch_Paths_paths_Item = cmdletContext.Paths_Item;
            }
            if (requestInvalidationBatch_invalidationBatch_Paths_paths_Item != null)
            {
                requestInvalidationBatch_invalidationBatch_Paths.Items = requestInvalidationBatch_invalidationBatch_Paths_paths_Item;
                requestInvalidationBatch_invalidationBatch_PathsIsNull = false;
            }
            System.Int32? requestInvalidationBatch_invalidationBatch_Paths_paths_Quantity = null;
            if (cmdletContext.Paths_Quantity != null)
            {
                requestInvalidationBatch_invalidationBatch_Paths_paths_Quantity = cmdletContext.Paths_Quantity.Value;
            }
            if (requestInvalidationBatch_invalidationBatch_Paths_paths_Quantity != null)
            {
                requestInvalidationBatch_invalidationBatch_Paths.Quantity = requestInvalidationBatch_invalidationBatch_Paths_paths_Quantity.Value;
                requestInvalidationBatch_invalidationBatch_PathsIsNull = false;
            }
             // determine if requestInvalidationBatch_invalidationBatch_Paths should be set to null
            if (requestInvalidationBatch_invalidationBatch_PathsIsNull)
            {
                requestInvalidationBatch_invalidationBatch_Paths = null;
            }
            if (requestInvalidationBatch_invalidationBatch_Paths != null)
            {
                request.InvalidationBatch.Paths = requestInvalidationBatch_invalidationBatch_Paths;
                requestInvalidationBatchIsNull = false;
            }
             // determine if request.InvalidationBatch should be set to null
            if (requestInvalidationBatchIsNull)
            {
                request.InvalidationBatch = null;
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
        
        private Amazon.CloudFront.Model.CreateInvalidationResponse CallAWSServiceOperation(IAmazonCloudFront client, Amazon.CloudFront.Model.CreateInvalidationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon CloudFront", "CreateInvalidation");
            try
            {
                #if DESKTOP
                return client.CreateInvalidation(request);
                #elif CORECLR
                return client.CreateInvalidationAsync(request).GetAwaiter().GetResult();
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
            public System.String DistributionId { get; set; }
            public System.String InvalidationBatch_CallerReference { get; set; }
            public List<System.String> Paths_Item { get; set; }
            public System.Int32? Paths_Quantity { get; set; }
            public System.Func<Amazon.CloudFront.Model.CreateInvalidationResponse, NewCFInvalidationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
