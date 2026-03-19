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
using Amazon.Batch;
using Amazon.Batch.Model;

namespace Amazon.PowerShell.Cmdlets.BAT
{
    /// <summary>
    /// Creates an Batch quota share. Each quota share operates as a virtual queue with a
    /// configured compute capacity, resource sharing strategy, and borrow limits.
    /// </summary>
    [Cmdlet("New", "BATQuotaShare", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Batch.Model.CreateQuotaShareResponse")]
    [AWSCmdlet("Calls the AWS Batch CreateQuotaShare API operation.", Operation = new[] {"CreateQuotaShare"}, SelectReturnType = typeof(Amazon.Batch.Model.CreateQuotaShareResponse))]
    [AWSCmdletOutput("Amazon.Batch.Model.CreateQuotaShareResponse",
        "This cmdlet returns an Amazon.Batch.Model.CreateQuotaShareResponse object containing multiple properties."
    )]
    public partial class NewBATQuotaShareCmdlet : AmazonBatchClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ResourceSharingConfiguration_BorrowLimit
        /// <summary>
        /// <para>
        /// <para>The maximum percentage of additional capacity that the quota share can borrow from
        /// other shares. <c>borrowLimit</c> can only be applied to quota shares with a strategy
        /// of <c>LEND_AND_BORROW</c>. This value is expressed as a percentage of the quota share's
        /// configured <a href="https://docs.aws.amazon.com/batch/latest/APIReference/API_QuotaShareCapacityLimit.html">CapacityLimits</a>.</para><para>The <c>borrowLimit</c> is applied uniformly across all capacity units. For example,
        /// if the <c>borrowLimit</c> is 200, the quota share can borrow up to 200% of its configured
        /// <c>maxCapacity</c> for each capacity unit. The default <c>borrowLimit</c> is -1, which
        /// indicates unlimited borrowing.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? ResourceSharingConfiguration_BorrowLimit { get; set; }
        #endregion
        
        #region Parameter CapacityLimit
        /// <summary>
        /// <para>
        /// <para>A list that specifies the quantity and type of compute capacity allocated to the quota
        /// share. </para>
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
        [Alias("CapacityLimits")]
        public Amazon.Batch.Model.QuotaShareCapacityLimit[] CapacityLimit { get; set; }
        #endregion
        
        #region Parameter PreemptionConfiguration_InSharePreemption
        /// <summary>
        /// <para>
        /// <para>Specifies whether jobs within a quota share can be preempted by another, higher priority
        /// job in the same quota share.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.Batch.QuotaShareInSharePreemptionState")]
        public Amazon.Batch.QuotaShareInSharePreemptionState PreemptionConfiguration_InSharePreemption { get; set; }
        #endregion
        
        #region Parameter JobQueue
        /// <summary>
        /// <para>
        /// <para>The Batch job queue associated with the quota share. This can be the job queue name
        /// or ARN. A job queue must be in the <c>VALID</c> state before you can associate it
        /// with a quota share.</para>
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
        public System.String JobQueue { get; set; }
        #endregion
        
        #region Parameter QuotaShareName
        /// <summary>
        /// <para>
        /// <para>The name of the quota share. It can be up to 128 characters long. It can contain uppercase
        /// and lowercase letters, numbers, hyphens (-), and underscores (_).</para>
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
        public System.String QuotaShareName { get; set; }
        #endregion
        
        #region Parameter State
        /// <summary>
        /// <para>
        /// <para>The state of the quota share. If the quota share is <c>ENABLED</c>, it is able to
        /// accept jobs. If the quota share is <c>DISABLED</c>, new jobs won't be accepted but
        /// jobs already submitted can finish. The default state is <c>ENABLED</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Batch.QuotaShareState")]
        public Amazon.Batch.QuotaShareState State { get; set; }
        #endregion
        
        #region Parameter ResourceSharingConfiguration_Strategy
        /// <summary>
        /// <para>
        /// <para>The resource sharing strategy for the quota share. The <c>RESERVE</c> strategy allows
        /// a quota share to reserve idle capacity for itself. <c>LEND</c> configures the share
        /// to lend its idle capacity to another share in need of capacity. The <c>LEND_AND_BORROW</c>
        /// strategy configures the share to borrow idle capacity from an underutilized share,
        /// as well as lend to another share.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.Batch.QuotaShareResourceSharingStrategy")]
        public Amazon.Batch.QuotaShareResourceSharingStrategy ResourceSharingConfiguration_Strategy { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The tags that you apply to the quota share to help you categorize and organize your
        /// resources. Each tag consists of a key and an optional value. For more information,
        /// see <a href="https://docs.aws.amazon.com/batch/latest/userguide/using-tags.html">Tagging
        /// your Batch resources</a> in <i>Batch User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Batch.Model.CreateQuotaShareResponse).
        /// Specifying the name of a property of type Amazon.Batch.Model.CreateQuotaShareResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.QuotaShareName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-BATQuotaShare (CreateQuotaShare)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Batch.Model.CreateQuotaShareResponse, NewBATQuotaShareCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.CapacityLimit != null)
            {
                context.CapacityLimit = new List<Amazon.Batch.Model.QuotaShareCapacityLimit>(this.CapacityLimit);
            }
            #if MODULAR
            if (this.CapacityLimit == null && ParameterWasBound(nameof(this.CapacityLimit)))
            {
                WriteWarning("You are passing $null as a value for parameter CapacityLimit which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.JobQueue = this.JobQueue;
            #if MODULAR
            if (this.JobQueue == null && ParameterWasBound(nameof(this.JobQueue)))
            {
                WriteWarning("You are passing $null as a value for parameter JobQueue which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.PreemptionConfiguration_InSharePreemption = this.PreemptionConfiguration_InSharePreemption;
            #if MODULAR
            if (this.PreemptionConfiguration_InSharePreemption == null && ParameterWasBound(nameof(this.PreemptionConfiguration_InSharePreemption)))
            {
                WriteWarning("You are passing $null as a value for parameter PreemptionConfiguration_InSharePreemption which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.QuotaShareName = this.QuotaShareName;
            #if MODULAR
            if (this.QuotaShareName == null && ParameterWasBound(nameof(this.QuotaShareName)))
            {
                WriteWarning("You are passing $null as a value for parameter QuotaShareName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ResourceSharingConfiguration_BorrowLimit = this.ResourceSharingConfiguration_BorrowLimit;
            context.ResourceSharingConfiguration_Strategy = this.ResourceSharingConfiguration_Strategy;
            #if MODULAR
            if (this.ResourceSharingConfiguration_Strategy == null && ParameterWasBound(nameof(this.ResourceSharingConfiguration_Strategy)))
            {
                WriteWarning("You are passing $null as a value for parameter ResourceSharingConfiguration_Strategy which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.State = this.State;
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (System.String)(this.Tag[hashKey]));
                }
            }
            
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
            var request = new Amazon.Batch.Model.CreateQuotaShareRequest();
            
            if (cmdletContext.CapacityLimit != null)
            {
                request.CapacityLimits = cmdletContext.CapacityLimit;
            }
            if (cmdletContext.JobQueue != null)
            {
                request.JobQueue = cmdletContext.JobQueue;
            }
            
             // populate PreemptionConfiguration
            var requestPreemptionConfigurationIsNull = true;
            request.PreemptionConfiguration = new Amazon.Batch.Model.QuotaSharePreemptionConfiguration();
            Amazon.Batch.QuotaShareInSharePreemptionState requestPreemptionConfiguration_preemptionConfiguration_InSharePreemption = null;
            if (cmdletContext.PreemptionConfiguration_InSharePreemption != null)
            {
                requestPreemptionConfiguration_preemptionConfiguration_InSharePreemption = cmdletContext.PreemptionConfiguration_InSharePreemption;
            }
            if (requestPreemptionConfiguration_preemptionConfiguration_InSharePreemption != null)
            {
                request.PreemptionConfiguration.InSharePreemption = requestPreemptionConfiguration_preemptionConfiguration_InSharePreemption;
                requestPreemptionConfigurationIsNull = false;
            }
             // determine if request.PreemptionConfiguration should be set to null
            if (requestPreemptionConfigurationIsNull)
            {
                request.PreemptionConfiguration = null;
            }
            if (cmdletContext.QuotaShareName != null)
            {
                request.QuotaShareName = cmdletContext.QuotaShareName;
            }
            
             // populate ResourceSharingConfiguration
            var requestResourceSharingConfigurationIsNull = true;
            request.ResourceSharingConfiguration = new Amazon.Batch.Model.QuotaShareResourceSharingConfiguration();
            System.Int32? requestResourceSharingConfiguration_resourceSharingConfiguration_BorrowLimit = null;
            if (cmdletContext.ResourceSharingConfiguration_BorrowLimit != null)
            {
                requestResourceSharingConfiguration_resourceSharingConfiguration_BorrowLimit = cmdletContext.ResourceSharingConfiguration_BorrowLimit.Value;
            }
            if (requestResourceSharingConfiguration_resourceSharingConfiguration_BorrowLimit != null)
            {
                request.ResourceSharingConfiguration.BorrowLimit = requestResourceSharingConfiguration_resourceSharingConfiguration_BorrowLimit.Value;
                requestResourceSharingConfigurationIsNull = false;
            }
            Amazon.Batch.QuotaShareResourceSharingStrategy requestResourceSharingConfiguration_resourceSharingConfiguration_Strategy = null;
            if (cmdletContext.ResourceSharingConfiguration_Strategy != null)
            {
                requestResourceSharingConfiguration_resourceSharingConfiguration_Strategy = cmdletContext.ResourceSharingConfiguration_Strategy;
            }
            if (requestResourceSharingConfiguration_resourceSharingConfiguration_Strategy != null)
            {
                request.ResourceSharingConfiguration.Strategy = requestResourceSharingConfiguration_resourceSharingConfiguration_Strategy;
                requestResourceSharingConfigurationIsNull = false;
            }
             // determine if request.ResourceSharingConfiguration should be set to null
            if (requestResourceSharingConfigurationIsNull)
            {
                request.ResourceSharingConfiguration = null;
            }
            if (cmdletContext.State != null)
            {
                request.State = cmdletContext.State;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
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
        
        private Amazon.Batch.Model.CreateQuotaShareResponse CallAWSServiceOperation(IAmazonBatch client, Amazon.Batch.Model.CreateQuotaShareRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Batch", "CreateQuotaShare");
            try
            {
                #if DESKTOP
                return client.CreateQuotaShare(request);
                #elif CORECLR
                return client.CreateQuotaShareAsync(request).GetAwaiter().GetResult();
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
            public List<Amazon.Batch.Model.QuotaShareCapacityLimit> CapacityLimit { get; set; }
            public System.String JobQueue { get; set; }
            public Amazon.Batch.QuotaShareInSharePreemptionState PreemptionConfiguration_InSharePreemption { get; set; }
            public System.String QuotaShareName { get; set; }
            public System.Int32? ResourceSharingConfiguration_BorrowLimit { get; set; }
            public Amazon.Batch.QuotaShareResourceSharingStrategy ResourceSharingConfiguration_Strategy { get; set; }
            public Amazon.Batch.QuotaShareState State { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.Batch.Model.CreateQuotaShareResponse, NewBATQuotaShareCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
