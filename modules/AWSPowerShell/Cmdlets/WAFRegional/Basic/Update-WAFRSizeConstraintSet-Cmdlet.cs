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
using Amazon.WAFRegional;
using Amazon.WAFRegional.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.WAFR
{
    /// <summary>
    /// <note><para>
    /// This is <b>AWS WAF Classic</b> documentation. For more information, see <a href="https://docs.aws.amazon.com/waf/latest/developerguide/classic-waf-chapter.html">AWS
    /// WAF Classic</a> in the developer guide.
    /// </para><para><b>For the latest version of AWS WAF</b>, use the AWS WAFV2 API and see the <a href="https://docs.aws.amazon.com/waf/latest/developerguide/waf-chapter.html">AWS
    /// WAF Developer Guide</a>. With the latest version, AWS WAF has a single set of endpoints
    /// for regional and global use. 
    /// </para></note><para>
    /// Inserts or deletes <a>SizeConstraint</a> objects (filters) in a <a>SizeConstraintSet</a>.
    /// For each <c>SizeConstraint</c> object, you specify the following values: 
    /// </para><ul><li><para>
    /// Whether to insert or delete the object from the array. If you want to change a <c>SizeConstraintSetUpdate</c>
    /// object, you delete the existing object and add a new one.
    /// </para></li><li><para>
    /// The part of a web request that you want AWS WAF to evaluate, such as the length of
    /// a query string or the length of the <c>User-Agent</c> header.
    /// </para></li><li><para>
    /// Whether to perform any transformations on the request, such as converting it to lowercase,
    /// before checking its length. Note that transformations of the request body are not
    /// supported because the AWS resource forwards only the first <c>8192</c> bytes of your
    /// request to AWS WAF.
    /// </para><para>
    /// You can only specify a single type of TextTransformation.
    /// </para></li><li><para>
    /// A <c>ComparisonOperator</c> used for evaluating the selected part of the request against
    /// the specified <c>Size</c>, such as equals, greater than, less than, and so on.
    /// </para></li><li><para>
    /// The length, in bytes, that you want AWS WAF to watch for in selected part of the request.
    /// The length is computed after applying the transformation.
    /// </para></li></ul><para>
    /// For example, you can add a <c>SizeConstraintSetUpdate</c> object that matches web
    /// requests in which the length of the <c>User-Agent</c> header is greater than 100 bytes.
    /// You can then configure AWS WAF to block those requests.
    /// </para><para>
    /// To create and configure a <c>SizeConstraintSet</c>, perform the following steps:
    /// </para><ol><li><para>
    /// Create a <c>SizeConstraintSet.</c> For more information, see <a>CreateSizeConstraintSet</a>.
    /// </para></li><li><para>
    /// Use <a>GetChangeToken</a> to get the change token that you provide in the <c>ChangeToken</c>
    /// parameter of an <c>UpdateSizeConstraintSet</c> request.
    /// </para></li><li><para>
    /// Submit an <c>UpdateSizeConstraintSet</c> request to specify the part of the request
    /// that you want AWS WAF to inspect (for example, the header or the URI) and the value
    /// that you want AWS WAF to watch for.
    /// </para></li></ol><para>
    /// For more information about how to use the AWS WAF API to allow or block HTTP requests,
    /// see the <a href="https://docs.aws.amazon.com/waf/latest/developerguide/">AWS WAF Developer
    /// Guide</a>.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "WAFRSizeConstraintSet", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS WAF Regional UpdateSizeConstraintSet API operation.", Operation = new[] {"UpdateSizeConstraintSet"}, SelectReturnType = typeof(Amazon.WAFRegional.Model.UpdateSizeConstraintSetResponse))]
    [AWSCmdletOutput("System.String or Amazon.WAFRegional.Model.UpdateSizeConstraintSetResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.WAFRegional.Model.UpdateSizeConstraintSetResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateWAFRSizeConstraintSetCmdlet : AmazonWAFRegionalClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ChangeToken
        /// <summary>
        /// <para>
        /// <para>The value returned by the most recent call to <a>GetChangeToken</a>.</para>
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
        public System.String ChangeToken { get; set; }
        #endregion
        
        #region Parameter SizeConstraintSetId
        /// <summary>
        /// <para>
        /// <para>The <c>SizeConstraintSetId</c> of the <a>SizeConstraintSet</a> that you want to update.
        /// <c>SizeConstraintSetId</c> is returned by <a>CreateSizeConstraintSet</a> and by <a>ListSizeConstraintSets</a>.</para>
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
        public System.String SizeConstraintSetId { get; set; }
        #endregion
        
        #region Parameter Update
        /// <summary>
        /// <para>
        /// <para>An array of <c>SizeConstraintSetUpdate</c> objects that you want to insert into or
        /// delete from a <a>SizeConstraintSet</a>. For more information, see the applicable data
        /// types:</para><ul><li><para><a>SizeConstraintSetUpdate</a>: Contains <c>Action</c> and <c>SizeConstraint</c></para></li><li><para><a>SizeConstraint</a>: Contains <c>FieldToMatch</c>, <c>TextTransformation</c>, <c>ComparisonOperator</c>,
        /// and <c>Size</c></para></li><li><para><a>FieldToMatch</a>: Contains <c>Data</c> and <c>Type</c></para></li></ul><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
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
        [Alias("Updates")]
        public Amazon.WAFRegional.Model.SizeConstraintSetUpdate[] Update { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ChangeToken'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.WAFRegional.Model.UpdateSizeConstraintSetResponse).
        /// Specifying the name of a property of type Amazon.WAFRegional.Model.UpdateSizeConstraintSetResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ChangeToken";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.SizeConstraintSetId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-WAFRSizeConstraintSet (UpdateSizeConstraintSet)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.WAFRegional.Model.UpdateSizeConstraintSetResponse, UpdateWAFRSizeConstraintSetCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ChangeToken = this.ChangeToken;
            #if MODULAR
            if (this.ChangeToken == null && ParameterWasBound(nameof(this.ChangeToken)))
            {
                WriteWarning("You are passing $null as a value for parameter ChangeToken which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SizeConstraintSetId = this.SizeConstraintSetId;
            #if MODULAR
            if (this.SizeConstraintSetId == null && ParameterWasBound(nameof(this.SizeConstraintSetId)))
            {
                WriteWarning("You are passing $null as a value for parameter SizeConstraintSetId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Update != null)
            {
                context.Update = new List<Amazon.WAFRegional.Model.SizeConstraintSetUpdate>(this.Update);
            }
            #if MODULAR
            if (this.Update == null && ParameterWasBound(nameof(this.Update)))
            {
                WriteWarning("You are passing $null as a value for parameter Update which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.WAFRegional.Model.UpdateSizeConstraintSetRequest();
            
            if (cmdletContext.ChangeToken != null)
            {
                request.ChangeToken = cmdletContext.ChangeToken;
            }
            if (cmdletContext.SizeConstraintSetId != null)
            {
                request.SizeConstraintSetId = cmdletContext.SizeConstraintSetId;
            }
            if (cmdletContext.Update != null)
            {
                request.Updates = cmdletContext.Update;
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
        
        private Amazon.WAFRegional.Model.UpdateSizeConstraintSetResponse CallAWSServiceOperation(IAmazonWAFRegional client, Amazon.WAFRegional.Model.UpdateSizeConstraintSetRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS WAF Regional", "UpdateSizeConstraintSet");
            try
            {
                return client.UpdateSizeConstraintSetAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ChangeToken { get; set; }
            public System.String SizeConstraintSetId { get; set; }
            public List<Amazon.WAFRegional.Model.SizeConstraintSetUpdate> Update { get; set; }
            public System.Func<Amazon.WAFRegional.Model.UpdateSizeConstraintSetResponse, UpdateWAFRSizeConstraintSetCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ChangeToken;
        }
        
    }
}
