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
using System.Threading;
using Amazon.ConnectCases;
using Amazon.ConnectCases.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.CCAS
{
    /// <summary>
    /// Updates fields on multiple cases in a single request. All cases must belong to the
    /// same domain. Set the title, status, and customer ID through the top-level <c>title</c>,
    /// <c>status</c>, and <c>customerId</c> parameters, and set other fields through the
    /// <c>fields</c> array.
    /// 
    ///  
    /// <para>
    /// Each case is processed independently. If some cases fail, the remaining cases are
    /// still updated. To determine whether individual cases failed, inspect the <c>failedCases</c>
    /// array in the response.
    /// </para><para>
    /// The entire request fails, and no cases are updated, in the following cases:
    /// </para><ul><li><para>
    /// The specified domain doesn't exist.
    /// </para></li><li><para>
    /// A reference ID doesn't match any case in the domain.
    /// </para></li><li><para>
    /// The request contains duplicate case IDs.
    /// </para></li><li><para>
    /// The request doesn't specify any update. Provide at least one entry in <c>fields</c>,
    /// or a <c>title</c>, <c>status</c>, or <c>customerId</c>.
    /// </para></li><li><para>
    /// A field identifier in <c>fields</c> doesn't resolve to a field in the domain, for
    /// example, an unknown field name.
    /// </para></li><li><para>
    /// A field name contains a pipe (<c>|</c>) or comma (<c>,</c>) character.
    /// </para></li><li><para><c>fields</c> includes <c>title</c>, <c>status</c>, or <c>customerId</c>.
    /// </para></li></ul><note><para>
    /// This operation uses the same IAM action as <a href="https://docs.aws.amazon.com/cases/latest/APIReference/API_UpdateCase.html">UpdateCase</a>
    /// (<c>cases:UpdateCase</c>). You can use the <c>cases:IsBatchAction</c> condition key
    /// in IAM policies to allow or deny batch operations independently from single-case operations.
    /// </para></note><note><para>
    /// If you provide a value for <c>performedBy.userArn</c>, you must also have <a href="https://docs.aws.amazon.com/connect/latest/APIReference/API_DescribeUser.html">DescribeUser</a>
    /// permission on the ARN of the user that you provide.
    /// </para></note><para><b>Endpoints</b>: See <a href="https://docs.aws.amazon.com/general/latest/gr/connect_region.html">Connect
    /// Customer endpoints and quotas</a>.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "CCASCaseBatch", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ConnectCases.Model.BatchUpdateCaseResponse")]
    [AWSCmdlet("Calls the Amazon Connect Cases BatchUpdateCase API operation.", Operation = new[] {"BatchUpdateCase"}, SelectReturnType = typeof(Amazon.ConnectCases.Model.BatchUpdateCaseResponse))]
    [AWSCmdletOutput("Amazon.ConnectCases.Model.BatchUpdateCaseResponse",
        "This cmdlet returns an Amazon.ConnectCases.Model.BatchUpdateCaseResponse object containing multiple properties."
    )]
    public partial class UpdateCCASCaseBatchCmdlet : AmazonConnectCasesClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Case
        /// <summary>
        /// <para>
        /// <para>The list of cases to update. All cases must belong to the same domain.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
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
        [Alias("Cases")]
        public Amazon.ConnectCases.Model.BatchUpdateCaseIdentifier[] Case { get; set; }
        #endregion
        
        #region Parameter PerformedBy_CustomEntity
        /// <summary>
        /// <para>
        /// <para>Any provided entity.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PerformedBy_CustomEntity { get; set; }
        #endregion
        
        #region Parameter CustomerId
        /// <summary>
        /// <para>
        /// <para>The ARN of the customer profile to associate with all cases in the request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CustomerId { get; set; }
        #endregion
        
        #region Parameter DomainId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the Cases domain. </para>
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
        public System.String DomainId { get; set; }
        #endregion
        
        #region Parameter Field
        /// <summary>
        /// <para>
        /// <para>An array of objects, each with a <c>fieldIdentifier</c> and a <c>value</c>. You can
        /// identify each field by its ID or by its name; identifying a field by name is supported
        /// only in <c>BatchUpdateCase</c>. The same field values are applied to every case in
        /// the request. This field must be present, but can be an empty list when you provide
        /// the top-level <c>title</c>, <c>status</c>, or <c>customerId</c> parameters. Do not
        /// include <c>title</c>, <c>status</c>, or <c>customerId</c> in this list; set those
        /// values only through their top-level parameters. Duplicating them in <c>fields</c>
        /// results in a validation error.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
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
        [Alias("Fields")]
        public Amazon.ConnectCases.Model.FieldValueInput[] Field { get; set; }
        #endregion
        
        #region Parameter Status
        /// <summary>
        /// <para>
        /// <para>The status to apply to all cases in the request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Status { get; set; }
        #endregion
        
        #region Parameter Title
        /// <summary>
        /// <para>
        /// <para>The title to apply to all cases in the request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Title { get; set; }
        #endregion
        
        #region Parameter PerformedBy_UserArn
        /// <summary>
        /// <para>
        /// <para>Represents the Connect Customer ARN of the user.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PerformedBy_UserArn { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive identifier that you provide to ensure the idempotency of
        /// the request. If not provided, the Amazon Web Services SDK populates this field. For
        /// more information about idempotency, see <a href="https://aws.amazon.com/builders-library/making-retries-safe-with-idempotent-APIs/">Making
        /// retries safe with idempotent APIs</a>.</para><para>If you retry a request with the same client token, the service returns the original
        /// response instead of processing the request again. If you reuse a client token with
        /// different request parameters, the request fails with a <c>ConflictException</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ConnectCases.Model.BatchUpdateCaseResponse).
        /// Specifying the name of a property of type Amazon.ConnectCases.Model.BatchUpdateCaseResponse will result in that property being returned.
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
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.DomainId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-CCASCaseBatch (BatchUpdateCase)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ConnectCases.Model.BatchUpdateCaseResponse, UpdateCCASCaseBatchCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.Case != null)
            {
                context.Case = new List<Amazon.ConnectCases.Model.BatchUpdateCaseIdentifier>(this.Case);
            }
            #if MODULAR
            if (this.Case == null && ParameterWasBound(nameof(this.Case)))
            {
                WriteWarning("You are passing $null as a value for parameter Case which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ClientToken = this.ClientToken;
            context.CustomerId = this.CustomerId;
            context.DomainId = this.DomainId;
            #if MODULAR
            if (this.DomainId == null && ParameterWasBound(nameof(this.DomainId)))
            {
                WriteWarning("You are passing $null as a value for parameter DomainId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Field != null)
            {
                context.Field = new List<Amazon.ConnectCases.Model.FieldValueInput>(this.Field);
            }
            #if MODULAR
            if (this.Field == null && ParameterWasBound(nameof(this.Field)))
            {
                WriteWarning("You are passing $null as a value for parameter Field which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.PerformedBy_CustomEntity = this.PerformedBy_CustomEntity;
            context.PerformedBy_UserArn = this.PerformedBy_UserArn;
            context.Status = this.Status;
            context.Title = this.Title;
            
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
            var request = new Amazon.ConnectCases.Model.BatchUpdateCaseRequest();
            
            if (cmdletContext.Case != null)
            {
                request.Cases = cmdletContext.Case;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.CustomerId != null)
            {
                request.CustomerId = cmdletContext.CustomerId;
            }
            if (cmdletContext.DomainId != null)
            {
                request.DomainId = cmdletContext.DomainId;
            }
            if (cmdletContext.Field != null)
            {
                request.Fields = cmdletContext.Field;
            }
            
             // populate PerformedBy
            var requestPerformedByIsNull = true;
            request.PerformedBy = new Amazon.ConnectCases.Model.UserUnion();
            System.String requestPerformedBy_performedBy_CustomEntity = null;
            if (cmdletContext.PerformedBy_CustomEntity != null)
            {
                requestPerformedBy_performedBy_CustomEntity = cmdletContext.PerformedBy_CustomEntity;
            }
            if (requestPerformedBy_performedBy_CustomEntity != null)
            {
                request.PerformedBy.CustomEntity = requestPerformedBy_performedBy_CustomEntity;
                requestPerformedByIsNull = false;
            }
            System.String requestPerformedBy_performedBy_UserArn = null;
            if (cmdletContext.PerformedBy_UserArn != null)
            {
                requestPerformedBy_performedBy_UserArn = cmdletContext.PerformedBy_UserArn;
            }
            if (requestPerformedBy_performedBy_UserArn != null)
            {
                request.PerformedBy.UserArn = requestPerformedBy_performedBy_UserArn;
                requestPerformedByIsNull = false;
            }
             // determine if request.PerformedBy should be set to null
            if (requestPerformedByIsNull)
            {
                request.PerformedBy = null;
            }
            if (cmdletContext.Status != null)
            {
                request.Status = cmdletContext.Status;
            }
            if (cmdletContext.Title != null)
            {
                request.Title = cmdletContext.Title;
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
        
        private Amazon.ConnectCases.Model.BatchUpdateCaseResponse CallAWSServiceOperation(IAmazonConnectCases client, Amazon.ConnectCases.Model.BatchUpdateCaseRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Connect Cases", "BatchUpdateCase");
            try
            {
                return client.BatchUpdateCaseAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<Amazon.ConnectCases.Model.BatchUpdateCaseIdentifier> Case { get; set; }
            public System.String ClientToken { get; set; }
            public System.String CustomerId { get; set; }
            public System.String DomainId { get; set; }
            public List<Amazon.ConnectCases.Model.FieldValueInput> Field { get; set; }
            public System.String PerformedBy_CustomEntity { get; set; }
            public System.String PerformedBy_UserArn { get; set; }
            public System.String Status { get; set; }
            public System.String Title { get; set; }
            public System.Func<Amazon.ConnectCases.Model.BatchUpdateCaseResponse, UpdateCCASCaseBatchCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
