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
    /// Inserts or deletes <a>SqlInjectionMatchTuple</a> objects (filters) in a <a>SqlInjectionMatchSet</a>.
    /// For each <c>SqlInjectionMatchTuple</c> object, you specify the following values:
    /// </para><ul><li><para><c>Action</c>: Whether to insert the object into or delete the object from the array.
    /// To change a <c>SqlInjectionMatchTuple</c>, you delete the existing object and add
    /// a new one.
    /// </para></li><li><para><c>FieldToMatch</c>: The part of web requests that you want AWS WAF to inspect and,
    /// if you want AWS WAF to inspect a header or custom query parameter, the name of the
    /// header or parameter.
    /// </para></li><li><para><c>TextTransformation</c>: Which text transformation, if any, to perform on the web
    /// request before inspecting the request for snippets of malicious SQL code.
    /// </para><para>
    /// You can only specify a single type of TextTransformation.
    /// </para></li></ul><para>
    /// You use <c>SqlInjectionMatchSet</c> objects to specify which CloudFront requests that
    /// you want to allow, block, or count. For example, if you're receiving requests that
    /// contain snippets of SQL code in the query string and you want to block the requests,
    /// you can create a <c>SqlInjectionMatchSet</c> with the applicable settings, and then
    /// configure AWS WAF to block the requests. 
    /// </para><para>
    /// To create and configure a <c>SqlInjectionMatchSet</c>, perform the following steps:
    /// </para><ol><li><para>
    /// Submit a <a>CreateSqlInjectionMatchSet</a> request.
    /// </para></li><li><para>
    /// Use <a>GetChangeToken</a> to get the change token that you provide in the <c>ChangeToken</c>
    /// parameter of an <a>UpdateIPSet</a> request.
    /// </para></li><li><para>
    /// Submit an <c>UpdateSqlInjectionMatchSet</c> request to specify the parts of web requests
    /// that you want AWS WAF to inspect for snippets of SQL code.
    /// </para></li></ol><para>
    /// For more information about how to use the AWS WAF API to allow or block HTTP requests,
    /// see the <a href="https://docs.aws.amazon.com/waf/latest/developerguide/">AWS WAF Developer
    /// Guide</a>.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "WAFRSqlInjectionMatchSet", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS WAF Regional UpdateSqlInjectionMatchSet API operation.", Operation = new[] {"UpdateSqlInjectionMatchSet"}, SelectReturnType = typeof(Amazon.WAFRegional.Model.UpdateSqlInjectionMatchSetResponse))]
    [AWSCmdletOutput("System.String or Amazon.WAFRegional.Model.UpdateSqlInjectionMatchSetResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.WAFRegional.Model.UpdateSqlInjectionMatchSetResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateWAFRSqlInjectionMatchSetCmdlet : AmazonWAFRegionalClientCmdlet, IExecutor
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
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String ChangeToken { get; set; }
        #endregion
        
        #region Parameter SqlInjectionMatchSetId
        /// <summary>
        /// <para>
        /// <para>The <c>SqlInjectionMatchSetId</c> of the <c>SqlInjectionMatchSet</c> that you want
        /// to update. <c>SqlInjectionMatchSetId</c> is returned by <a>CreateSqlInjectionMatchSet</a>
        /// and by <a>ListSqlInjectionMatchSets</a>.</para>
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
        public System.String SqlInjectionMatchSetId { get; set; }
        #endregion
        
        #region Parameter Update
        /// <summary>
        /// <para>
        /// <para>An array of <c>SqlInjectionMatchSetUpdate</c> objects that you want to insert into
        /// or delete from a <a>SqlInjectionMatchSet</a>. For more information, see the applicable
        /// data types:</para><ul><li><para><a>SqlInjectionMatchSetUpdate</a>: Contains <c>Action</c> and <c>SqlInjectionMatchTuple</c></para></li><li><para><a>SqlInjectionMatchTuple</a>: Contains <c>FieldToMatch</c> and <c>TextTransformation</c></para></li><li><para><a>FieldToMatch</a>: Contains <c>Data</c> and <c>Type</c></para></li></ul>
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
        public Amazon.WAFRegional.Model.SqlInjectionMatchSetUpdate[] Update { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ChangeToken'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.WAFRegional.Model.UpdateSqlInjectionMatchSetResponse).
        /// Specifying the name of a property of type Amazon.WAFRegional.Model.UpdateSqlInjectionMatchSetResponse will result in that property being returned.
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.SqlInjectionMatchSetId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-WAFRSqlInjectionMatchSet (UpdateSqlInjectionMatchSet)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.WAFRegional.Model.UpdateSqlInjectionMatchSetResponse, UpdateWAFRSqlInjectionMatchSetCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ChangeToken = this.ChangeToken;
            #if MODULAR
            if (this.ChangeToken == null && ParameterWasBound(nameof(this.ChangeToken)))
            {
                WriteWarning("You are passing $null as a value for parameter ChangeToken which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SqlInjectionMatchSetId = this.SqlInjectionMatchSetId;
            #if MODULAR
            if (this.SqlInjectionMatchSetId == null && ParameterWasBound(nameof(this.SqlInjectionMatchSetId)))
            {
                WriteWarning("You are passing $null as a value for parameter SqlInjectionMatchSetId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Update != null)
            {
                context.Update = new List<Amazon.WAFRegional.Model.SqlInjectionMatchSetUpdate>(this.Update);
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
            var request = new Amazon.WAFRegional.Model.UpdateSqlInjectionMatchSetRequest();
            
            if (cmdletContext.ChangeToken != null)
            {
                request.ChangeToken = cmdletContext.ChangeToken;
            }
            if (cmdletContext.SqlInjectionMatchSetId != null)
            {
                request.SqlInjectionMatchSetId = cmdletContext.SqlInjectionMatchSetId;
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
        
        private Amazon.WAFRegional.Model.UpdateSqlInjectionMatchSetResponse CallAWSServiceOperation(IAmazonWAFRegional client, Amazon.WAFRegional.Model.UpdateSqlInjectionMatchSetRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS WAF Regional", "UpdateSqlInjectionMatchSet");
            try
            {
                return client.UpdateSqlInjectionMatchSetAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String SqlInjectionMatchSetId { get; set; }
            public List<Amazon.WAFRegional.Model.SqlInjectionMatchSetUpdate> Update { get; set; }
            public System.Func<Amazon.WAFRegional.Model.UpdateSqlInjectionMatchSetResponse, UpdateWAFRSqlInjectionMatchSetCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ChangeToken;
        }
        
    }
}
