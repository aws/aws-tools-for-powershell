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
using Amazon.WAF;
using Amazon.WAF.Model;

namespace Amazon.PowerShell.Cmdlets.WAF
{
    /// <summary>
    /// <note><para>
    /// This is <b>AWS WAF Classic</b> documentation. For more information, see <a href="https://docs.aws.amazon.com/waf/latest/developerguide/classic-waf-chapter.html">AWS
    /// WAF Classic</a> in the developer guide.
    /// </para><para><b>For the latest version of AWS WAF</b>, use the AWS WAFV2 API and see the <a href="https://docs.aws.amazon.com/waf/latest/developerguide/waf-chapter.html">AWS
    /// WAF Developer Guide</a>. With the latest version, AWS WAF has a single set of endpoints
    /// for regional and global use. 
    /// </para></note><para>
    /// Inserts or deletes <a>ByteMatchTuple</a> objects (filters) in a <a>ByteMatchSet</a>.
    /// For each <c>ByteMatchTuple</c> object, you specify the following values: 
    /// </para><ul><li><para>
    /// Whether to insert or delete the object from the array. If you want to change a <c>ByteMatchSetUpdate</c>
    /// object, you delete the existing object and add a new one.
    /// </para></li><li><para>
    /// The part of a web request that you want AWS WAF to inspect, such as a query string
    /// or the value of the <c>User-Agent</c> header. 
    /// </para></li><li><para>
    /// The bytes (typically a string that corresponds with ASCII characters) that you want
    /// AWS WAF to look for. For more information, including how you specify the values for
    /// the AWS WAF API and the AWS CLI or SDKs, see <c>TargetString</c> in the <a>ByteMatchTuple</a>
    /// data type. 
    /// </para></li><li><para>
    /// Where to look, such as at the beginning or the end of a query string.
    /// </para></li><li><para>
    /// Whether to perform any conversions on the request, such as converting it to lowercase,
    /// before inspecting it for the specified string.
    /// </para></li></ul><para>
    /// For example, you can add a <c>ByteMatchSetUpdate</c> object that matches web requests
    /// in which <c>User-Agent</c> headers contain the string <c>BadBot</c>. You can then
    /// configure AWS WAF to block those requests.
    /// </para><para>
    /// To create and configure a <c>ByteMatchSet</c>, perform the following steps:
    /// </para><ol><li><para>
    /// Create a <c>ByteMatchSet.</c> For more information, see <a>CreateByteMatchSet</a>.
    /// </para></li><li><para>
    /// Use <a>GetChangeToken</a> to get the change token that you provide in the <c>ChangeToken</c>
    /// parameter of an <c>UpdateByteMatchSet</c> request.
    /// </para></li><li><para>
    /// Submit an <c>UpdateByteMatchSet</c> request to specify the part of the request that
    /// you want AWS WAF to inspect (for example, the header or the URI) and the value that
    /// you want AWS WAF to watch for.
    /// </para></li></ol><para>
    /// For more information about how to use the AWS WAF API to allow or block HTTP requests,
    /// see the <a href="https://docs.aws.amazon.com/waf/latest/developerguide/">AWS WAF Developer
    /// Guide</a>.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "WAFByteMatchSet", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS WAF UpdateByteMatchSet API operation.", Operation = new[] {"UpdateByteMatchSet"}, SelectReturnType = typeof(Amazon.WAF.Model.UpdateByteMatchSetResponse))]
    [AWSCmdletOutput("System.String or Amazon.WAF.Model.UpdateByteMatchSetResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.WAF.Model.UpdateByteMatchSetResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateWAFByteMatchSetCmdlet : AmazonWAFClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ByteMatchSetId
        /// <summary>
        /// <para>
        /// <para>The <c>ByteMatchSetId</c> of the <a>ByteMatchSet</a> that you want to update. <c>ByteMatchSetId</c>
        /// is returned by <a>CreateByteMatchSet</a> and by <a>ListByteMatchSets</a>.</para>
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
        public System.String ByteMatchSetId { get; set; }
        #endregion
        
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
        
        #region Parameter Update
        /// <summary>
        /// <para>
        /// <para>An array of <c>ByteMatchSetUpdate</c> objects that you want to insert into or delete
        /// from a <a>ByteMatchSet</a>. For more information, see the applicable data types:</para><ul><li><para><a>ByteMatchSetUpdate</a>: Contains <c>Action</c> and <c>ByteMatchTuple</c></para></li><li><para><a>ByteMatchTuple</a>: Contains <c>FieldToMatch</c>, <c>PositionalConstraint</c>,
        /// <c>TargetString</c>, and <c>TextTransformation</c></para></li><li><para><a>FieldToMatch</a>: Contains <c>Data</c> and <c>Type</c></para></li></ul>
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
        public Amazon.WAF.Model.ByteMatchSetUpdate[] Update { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ChangeToken'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.WAF.Model.UpdateByteMatchSetResponse).
        /// Specifying the name of a property of type Amazon.WAF.Model.UpdateByteMatchSetResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ChangeToken";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ByteMatchSetId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ByteMatchSetId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ByteMatchSetId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ByteMatchSetId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-WAFByteMatchSet (UpdateByteMatchSet)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.WAF.Model.UpdateByteMatchSetResponse, UpdateWAFByteMatchSetCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ByteMatchSetId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ByteMatchSetId = this.ByteMatchSetId;
            #if MODULAR
            if (this.ByteMatchSetId == null && ParameterWasBound(nameof(this.ByteMatchSetId)))
            {
                WriteWarning("You are passing $null as a value for parameter ByteMatchSetId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ChangeToken = this.ChangeToken;
            #if MODULAR
            if (this.ChangeToken == null && ParameterWasBound(nameof(this.ChangeToken)))
            {
                WriteWarning("You are passing $null as a value for parameter ChangeToken which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Update != null)
            {
                context.Update = new List<Amazon.WAF.Model.ByteMatchSetUpdate>(this.Update);
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
            var request = new Amazon.WAF.Model.UpdateByteMatchSetRequest();
            
            if (cmdletContext.ByteMatchSetId != null)
            {
                request.ByteMatchSetId = cmdletContext.ByteMatchSetId;
            }
            if (cmdletContext.ChangeToken != null)
            {
                request.ChangeToken = cmdletContext.ChangeToken;
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
        
        private Amazon.WAF.Model.UpdateByteMatchSetResponse CallAWSServiceOperation(IAmazonWAF client, Amazon.WAF.Model.UpdateByteMatchSetRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS WAF", "UpdateByteMatchSet");
            try
            {
                #if DESKTOP
                return client.UpdateByteMatchSet(request);
                #elif CORECLR
                return client.UpdateByteMatchSetAsync(request).GetAwaiter().GetResult();
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
            public System.String ByteMatchSetId { get; set; }
            public System.String ChangeToken { get; set; }
            public List<Amazon.WAF.Model.ByteMatchSetUpdate> Update { get; set; }
            public System.Func<Amazon.WAF.Model.UpdateByteMatchSetResponse, UpdateWAFByteMatchSetCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ChangeToken;
        }
        
    }
}
