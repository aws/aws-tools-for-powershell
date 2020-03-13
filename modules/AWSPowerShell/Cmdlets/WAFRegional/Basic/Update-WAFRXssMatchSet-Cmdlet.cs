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
    /// Inserts or deletes <a>XssMatchTuple</a> objects (filters) in an <a>XssMatchSet</a>.
    /// For each <code>XssMatchTuple</code> object, you specify the following values:
    /// </para><ul><li><para><code>Action</code>: Whether to insert the object into or delete the object from
    /// the array. To change an <code>XssMatchTuple</code>, you delete the existing object
    /// and add a new one.
    /// </para></li><li><para><code>FieldToMatch</code>: The part of web requests that you want AWS WAF to inspect
    /// and, if you want AWS WAF to inspect a header or custom query parameter, the name of
    /// the header or parameter.
    /// </para></li><li><para><code>TextTransformation</code>: Which text transformation, if any, to perform on
    /// the web request before inspecting the request for cross-site scripting attacks.
    /// </para><para>
    /// You can only specify a single type of TextTransformation.
    /// </para></li></ul><para>
    /// You use <code>XssMatchSet</code> objects to specify which CloudFront requests that
    /// you want to allow, block, or count. For example, if you're receiving requests that
    /// contain cross-site scripting attacks in the request body and you want to block the
    /// requests, you can create an <code>XssMatchSet</code> with the applicable settings,
    /// and then configure AWS WAF to block the requests. 
    /// </para><para>
    /// To create and configure an <code>XssMatchSet</code>, perform the following steps:
    /// </para><ol><li><para>
    /// Submit a <a>CreateXssMatchSet</a> request.
    /// </para></li><li><para>
    /// Use <a>GetChangeToken</a> to get the change token that you provide in the <code>ChangeToken</code>
    /// parameter of an <a>UpdateIPSet</a> request.
    /// </para></li><li><para>
    /// Submit an <code>UpdateXssMatchSet</code> request to specify the parts of web requests
    /// that you want AWS WAF to inspect for cross-site scripting attacks.
    /// </para></li></ol><para>
    /// For more information about how to use the AWS WAF API to allow or block HTTP requests,
    /// see the <a href="https://docs.aws.amazon.com/waf/latest/developerguide/">AWS WAF Developer
    /// Guide</a>.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "WAFRXssMatchSet", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS WAF Regional UpdateXssMatchSet API operation.", Operation = new[] {"UpdateXssMatchSet"}, SelectReturnType = typeof(Amazon.WAFRegional.Model.UpdateXssMatchSetResponse))]
    [AWSCmdletOutput("System.String or Amazon.WAFRegional.Model.UpdateXssMatchSetResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.WAFRegional.Model.UpdateXssMatchSetResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateWAFRXssMatchSetCmdlet : AmazonWAFRegionalClientCmdlet, IExecutor
    {
        
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
        
        #region Parameter Update
        /// <summary>
        /// <para>
        /// <para>An array of <code>XssMatchSetUpdate</code> objects that you want to insert into or
        /// delete from an <a>XssMatchSet</a>. For more information, see the applicable data types:</para><ul><li><para><a>XssMatchSetUpdate</a>: Contains <code>Action</code> and <code>XssMatchTuple</code></para></li><li><para><a>XssMatchTuple</a>: Contains <code>FieldToMatch</code> and <code>TextTransformation</code></para></li><li><para><a>FieldToMatch</a>: Contains <code>Data</code> and <code>Type</code></para></li></ul>
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
        public Amazon.WAFRegional.Model.XssMatchSetUpdate[] Update { get; set; }
        #endregion
        
        #region Parameter XssMatchSetId
        /// <summary>
        /// <para>
        /// <para>The <code>XssMatchSetId</code> of the <code>XssMatchSet</code> that you want to update.
        /// <code>XssMatchSetId</code> is returned by <a>CreateXssMatchSet</a> and by <a>ListXssMatchSets</a>.</para>
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
        public System.String XssMatchSetId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ChangeToken'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.WAFRegional.Model.UpdateXssMatchSetResponse).
        /// Specifying the name of a property of type Amazon.WAFRegional.Model.UpdateXssMatchSetResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ChangeToken";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ChangeToken parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ChangeToken' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ChangeToken' instead. This parameter will be removed in a future version.")]
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.XssMatchSetId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-WAFRXssMatchSet (UpdateXssMatchSet)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.WAFRegional.Model.UpdateXssMatchSetResponse, UpdateWAFRXssMatchSetCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ChangeToken;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ChangeToken = this.ChangeToken;
            #if MODULAR
            if (this.ChangeToken == null && ParameterWasBound(nameof(this.ChangeToken)))
            {
                WriteWarning("You are passing $null as a value for parameter ChangeToken which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Update != null)
            {
                context.Update = new List<Amazon.WAFRegional.Model.XssMatchSetUpdate>(this.Update);
            }
            #if MODULAR
            if (this.Update == null && ParameterWasBound(nameof(this.Update)))
            {
                WriteWarning("You are passing $null as a value for parameter Update which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.XssMatchSetId = this.XssMatchSetId;
            #if MODULAR
            if (this.XssMatchSetId == null && ParameterWasBound(nameof(this.XssMatchSetId)))
            {
                WriteWarning("You are passing $null as a value for parameter XssMatchSetId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.WAFRegional.Model.UpdateXssMatchSetRequest();
            
            if (cmdletContext.ChangeToken != null)
            {
                request.ChangeToken = cmdletContext.ChangeToken;
            }
            if (cmdletContext.Update != null)
            {
                request.Updates = cmdletContext.Update;
            }
            if (cmdletContext.XssMatchSetId != null)
            {
                request.XssMatchSetId = cmdletContext.XssMatchSetId;
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
        
        private Amazon.WAFRegional.Model.UpdateXssMatchSetResponse CallAWSServiceOperation(IAmazonWAFRegional client, Amazon.WAFRegional.Model.UpdateXssMatchSetRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS WAF Regional", "UpdateXssMatchSet");
            try
            {
                #if DESKTOP
                return client.UpdateXssMatchSet(request);
                #elif CORECLR
                return client.UpdateXssMatchSetAsync(request).GetAwaiter().GetResult();
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
            public System.String ChangeToken { get; set; }
            public List<Amazon.WAFRegional.Model.XssMatchSetUpdate> Update { get; set; }
            public System.String XssMatchSetId { get; set; }
            public System.Func<Amazon.WAFRegional.Model.UpdateXssMatchSetResponse, UpdateWAFRXssMatchSetCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ChangeToken;
        }
        
    }
}
