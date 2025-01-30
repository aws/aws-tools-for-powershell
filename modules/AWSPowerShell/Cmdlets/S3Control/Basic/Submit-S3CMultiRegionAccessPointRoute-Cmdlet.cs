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
using Amazon.S3Control;
using Amazon.S3Control.Model;

namespace Amazon.PowerShell.Cmdlets.S3C
{
    /// <summary>
    /// <note><para>
    /// This operation is not supported by directory buckets.
    /// </para></note><para>
    /// Submits an updated route configuration for a Multi-Region Access Point. This API operation
    /// updates the routing status for the specified Regions from active to passive, or from
    /// passive to active. A value of <c>0</c> indicates a passive status, which means that
    /// traffic won't be routed to the specified Region. A value of <c>100</c> indicates an
    /// active status, which means that traffic will be routed to the specified Region. At
    /// least one Region must be active at all times.
    /// </para><para>
    /// When the routing configuration is changed, any in-progress operations (uploads, copies,
    /// deletes, and so on) to formerly active Regions will continue to run to their final
    /// completion state (success or failure). The routing configurations of any Regions that
    /// aren’t specified remain unchanged.
    /// </para><note><para>
    /// Updated routing configurations might not be immediately applied. It can take up to
    /// 2 minutes for your changes to take effect.
    /// </para></note><para>
    /// To submit routing control changes and failover requests, use the Amazon S3 failover
    /// control infrastructure endpoints in these five Amazon Web Services Regions:
    /// </para><ul><li><para><c>us-east-1</c></para></li><li><para><c>us-west-2</c></para></li><li><para><c>ap-southeast-2</c></para></li><li><para><c>ap-northeast-1</c></para></li><li><para><c>eu-west-1</c></para></li></ul>
    /// </summary>
    [Cmdlet("Submit", "S3CMultiRegionAccessPointRoute", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon S3 Control SubmitMultiRegionAccessPointRoutes API operation.", Operation = new[] {"SubmitMultiRegionAccessPointRoutes"}, SelectReturnType = typeof(Amazon.S3Control.Model.SubmitMultiRegionAccessPointRoutesResponse))]
    [AWSCmdletOutput("None or Amazon.S3Control.Model.SubmitMultiRegionAccessPointRoutesResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.S3Control.Model.SubmitMultiRegionAccessPointRoutesResponse) be returned by specifying '-Select *'."
    )]
    public partial class SubmitS3CMultiRegionAccessPointRouteCmdlet : AmazonS3ControlClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AccountId
        /// <summary>
        /// <para>
        /// <para>The Amazon Web Services account ID for the owner of the Multi-Region Access Point.</para>
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
        public System.String AccountId { get; set; }
        #endregion
        
        #region Parameter Mrap
        /// <summary>
        /// <para>
        /// <para>The Multi-Region Access Point ARN.</para>
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
        public System.String Mrap { get; set; }
        #endregion
        
        #region Parameter RouteUpdate
        /// <summary>
        /// <para>
        /// <para>The different routes that make up the new route configuration. Active routes return
        /// a value of <c>100</c>, and passive routes return a value of <c>0</c>.</para>
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
        [Alias("RouteUpdates")]
        public Amazon.S3Control.Model.MultiRegionAccessPointRoute[] RouteUpdate { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.S3Control.Model.SubmitMultiRegionAccessPointRoutesResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Mrap parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Mrap' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Mrap' instead. This parameter will be removed in a future version.")]
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
            this._AWSSignerType = "s3v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.AccountId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Submit-S3CMultiRegionAccessPointRoute (SubmitMultiRegionAccessPointRoutes)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.S3Control.Model.SubmitMultiRegionAccessPointRoutesResponse, SubmitS3CMultiRegionAccessPointRouteCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Mrap;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AccountId = this.AccountId;
            #if MODULAR
            if (this.AccountId == null && ParameterWasBound(nameof(this.AccountId)))
            {
                WriteWarning("You are passing $null as a value for parameter AccountId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Mrap = this.Mrap;
            #if MODULAR
            if (this.Mrap == null && ParameterWasBound(nameof(this.Mrap)))
            {
                WriteWarning("You are passing $null as a value for parameter Mrap which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.RouteUpdate != null)
            {
                context.RouteUpdate = new List<Amazon.S3Control.Model.MultiRegionAccessPointRoute>(this.RouteUpdate);
            }
            #if MODULAR
            if (this.RouteUpdate == null && ParameterWasBound(nameof(this.RouteUpdate)))
            {
                WriteWarning("You are passing $null as a value for parameter RouteUpdate which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.S3Control.Model.SubmitMultiRegionAccessPointRoutesRequest();
            
            if (cmdletContext.AccountId != null)
            {
                request.AccountId = cmdletContext.AccountId;
            }
            if (cmdletContext.Mrap != null)
            {
                request.Mrap = cmdletContext.Mrap;
            }
            if (cmdletContext.RouteUpdate != null)
            {
                request.RouteUpdates = cmdletContext.RouteUpdate;
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
        
        private Amazon.S3Control.Model.SubmitMultiRegionAccessPointRoutesResponse CallAWSServiceOperation(IAmazonS3Control client, Amazon.S3Control.Model.SubmitMultiRegionAccessPointRoutesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon S3 Control", "SubmitMultiRegionAccessPointRoutes");
            try
            {
                #if DESKTOP
                return client.SubmitMultiRegionAccessPointRoutes(request);
                #elif CORECLR
                return client.SubmitMultiRegionAccessPointRoutesAsync(request).GetAwaiter().GetResult();
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
            public System.String AccountId { get; set; }
            public System.String Mrap { get; set; }
            public List<Amazon.S3Control.Model.MultiRegionAccessPointRoute> RouteUpdate { get; set; }
            public System.Func<Amazon.S3Control.Model.SubmitMultiRegionAccessPointRoutesResponse, SubmitS3CMultiRegionAccessPointRouteCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
