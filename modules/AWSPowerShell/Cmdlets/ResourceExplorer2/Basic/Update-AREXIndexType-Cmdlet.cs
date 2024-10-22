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
using Amazon.ResourceExplorer2;
using Amazon.ResourceExplorer2.Model;

namespace Amazon.PowerShell.Cmdlets.AREX
{
    /// <summary>
    /// Changes the type of the index from one of the following types to the other. For more
    /// information about indexes and the role they perform in Amazon Web Services Resource
    /// Explorer, see <a href="https://docs.aws.amazon.com/resource-explorer/latest/userguide/manage-aggregator-region.html">Turning
    /// on cross-Region search by creating an aggregator index</a> in the <i>Amazon Web Services
    /// Resource Explorer User Guide</i>.
    /// 
    ///  <ul><li><para><b><c>AGGREGATOR</c> index type</b></para><para>
    /// The index contains information about resources from all Amazon Web Services Regions
    /// in the Amazon Web Services account in which you've created a Resource Explorer index.
    /// Resource information from all other Regions is replicated to this Region's index.
    /// </para><para>
    /// When you change the index type to <c>AGGREGATOR</c>, Resource Explorer turns on replication
    /// of all discovered resource information from the other Amazon Web Services Regions
    /// in your account to this index. You can then, from this Region only, perform resource
    /// search queries that span all Amazon Web Services Regions in the Amazon Web Services
    /// account. Turning on replication from all other Regions is performed by asynchronous
    /// background tasks. You can check the status of the asynchronous tasks by using the
    /// <a>GetIndex</a> operation. When the asynchronous tasks complete, the <c>Status</c>
    /// response of that operation changes from <c>UPDATING</c> to <c>ACTIVE</c>. After that,
    /// you can start to see results from other Amazon Web Services Regions in query results.
    /// However, it can take several hours for replication from all other Regions to complete.
    /// </para><important><para>
    /// You can have only one aggregator index per Amazon Web Services account. Before you
    /// can promote a different index to be the aggregator index for the account, you must
    /// first demote the existing aggregator index to type <c>LOCAL</c>.
    /// </para></important></li><li><para><b><c>LOCAL</c> index type</b></para><para>
    /// The index contains information about resources in only the Amazon Web Services Region
    /// in which the index exists. If an aggregator index in another Region exists, then information
    /// in this local index is replicated to the aggregator index.
    /// </para><para>
    /// When you change the index type to <c>LOCAL</c>, Resource Explorer turns off the replication
    /// of resource information from all other Amazon Web Services Regions in the Amazon Web
    /// Services account to this Region. The aggregator index remains in the <c>UPDATING</c>
    /// state until all replication with other Regions successfully stops. You can check the
    /// status of the asynchronous task by using the <a>GetIndex</a> operation. When Resource
    /// Explorer successfully stops all replication with other Regions, the <c>Status</c>
    /// response of that operation changes from <c>UPDATING</c> to <c>ACTIVE</c>. Separately,
    /// the resource information from other Regions that was previously stored in the index
    /// is deleted within 30 days by another background task. Until that asynchronous task
    /// completes, some results from other Regions can continue to appear in search results.
    /// </para><important><para>
    /// After you demote an aggregator index to a local index, you must wait 24 hours before
    /// you can promote another index to be the new aggregator index for the account.
    /// </para></important></li></ul>
    /// </summary>
    [Cmdlet("Update", "AREXIndexType", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ResourceExplorer2.Model.UpdateIndexTypeResponse")]
    [AWSCmdlet("Calls the AWS Resource Explorer UpdateIndexType API operation.", Operation = new[] {"UpdateIndexType"}, SelectReturnType = typeof(Amazon.ResourceExplorer2.Model.UpdateIndexTypeResponse))]
    [AWSCmdletOutput("Amazon.ResourceExplorer2.Model.UpdateIndexTypeResponse",
        "This cmdlet returns an Amazon.ResourceExplorer2.Model.UpdateIndexTypeResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateAREXIndexTypeCmdlet : AmazonResourceExplorer2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Arn
        /// <summary>
        /// <para>
        /// <para>The <a href="https://docs.aws.amazon.com/general/latest/gr/aws-arns-and-namespaces.html">Amazon
        /// resource name (ARN)</a> of the index that you want to update.</para>
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
        public System.String Arn { get; set; }
        #endregion
        
        #region Parameter Type
        /// <summary>
        /// <para>
        /// <para>The type of the index. To understand the difference between <c>LOCAL</c> and <c>AGGREGATOR</c>,
        /// see <a href="https://docs.aws.amazon.com/resource-explorer/latest/userguide/manage-aggregator-region.html">Turning
        /// on cross-Region search</a> in the <i>Amazon Web Services Resource Explorer User Guide</i>.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.ResourceExplorer2.IndexType")]
        public Amazon.ResourceExplorer2.IndexType Type { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ResourceExplorer2.Model.UpdateIndexTypeResponse).
        /// Specifying the name of a property of type Amazon.ResourceExplorer2.Model.UpdateIndexTypeResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Arn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-AREXIndexType (UpdateIndexType)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ResourceExplorer2.Model.UpdateIndexTypeResponse, UpdateAREXIndexTypeCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Arn = this.Arn;
            #if MODULAR
            if (this.Arn == null && ParameterWasBound(nameof(this.Arn)))
            {
                WriteWarning("You are passing $null as a value for parameter Arn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Type = this.Type;
            #if MODULAR
            if (this.Type == null && ParameterWasBound(nameof(this.Type)))
            {
                WriteWarning("You are passing $null as a value for parameter Type which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.ResourceExplorer2.Model.UpdateIndexTypeRequest();
            
            if (cmdletContext.Arn != null)
            {
                request.Arn = cmdletContext.Arn;
            }
            if (cmdletContext.Type != null)
            {
                request.Type = cmdletContext.Type;
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
        
        private Amazon.ResourceExplorer2.Model.UpdateIndexTypeResponse CallAWSServiceOperation(IAmazonResourceExplorer2 client, Amazon.ResourceExplorer2.Model.UpdateIndexTypeRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Resource Explorer", "UpdateIndexType");
            try
            {
                #if DESKTOP
                return client.UpdateIndexType(request);
                #elif CORECLR
                return client.UpdateIndexTypeAsync(request).GetAwaiter().GetResult();
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
            public System.String Arn { get; set; }
            public Amazon.ResourceExplorer2.IndexType Type { get; set; }
            public System.Func<Amazon.ResourceExplorer2.Model.UpdateIndexTypeResponse, UpdateAREXIndexTypeCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
