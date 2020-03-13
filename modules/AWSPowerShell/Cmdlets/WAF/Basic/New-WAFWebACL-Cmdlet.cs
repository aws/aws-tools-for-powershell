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
    /// Creates a <code>WebACL</code>, which contains the <code>Rules</code> that identify
    /// the CloudFront web requests that you want to allow, block, or count. AWS WAF evaluates
    /// <code>Rules</code> in order based on the value of <code>Priority</code> for each <code>Rule</code>.
    /// </para><para>
    /// You also specify a default action, either <code>ALLOW</code> or <code>BLOCK</code>.
    /// If a web request doesn't match any of the <code>Rules</code> in a <code>WebACL</code>,
    /// AWS WAF responds to the request with the default action. 
    /// </para><para>
    /// To create and configure a <code>WebACL</code>, perform the following steps:
    /// </para><ol><li><para>
    /// Create and update the <code>ByteMatchSet</code> objects and other predicates that
    /// you want to include in <code>Rules</code>. For more information, see <a>CreateByteMatchSet</a>,
    /// <a>UpdateByteMatchSet</a>, <a>CreateIPSet</a>, <a>UpdateIPSet</a>, <a>CreateSqlInjectionMatchSet</a>,
    /// and <a>UpdateSqlInjectionMatchSet</a>.
    /// </para></li><li><para>
    /// Create and update the <code>Rules</code> that you want to include in the <code>WebACL</code>.
    /// For more information, see <a>CreateRule</a> and <a>UpdateRule</a>.
    /// </para></li><li><para>
    /// Use <a>GetChangeToken</a> to get the change token that you provide in the <code>ChangeToken</code>
    /// parameter of a <code>CreateWebACL</code> request.
    /// </para></li><li><para>
    /// Submit a <code>CreateWebACL</code> request.
    /// </para></li><li><para>
    /// Use <code>GetChangeToken</code> to get the change token that you provide in the <code>ChangeToken</code>
    /// parameter of an <a>UpdateWebACL</a> request.
    /// </para></li><li><para>
    /// Submit an <a>UpdateWebACL</a> request to specify the <code>Rules</code> that you want
    /// to include in the <code>WebACL</code>, to specify the default action, and to associate
    /// the <code>WebACL</code> with a CloudFront distribution.
    /// </para></li></ol><para>
    /// For more information about how to use the AWS WAF API, see the <a href="https://docs.aws.amazon.com/waf/latest/developerguide/">AWS
    /// WAF Developer Guide</a>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "WAFWebACL")]
    [OutputType("Amazon.WAF.Model.CreateWebACLResponse")]
    [AWSCmdlet("Calls the AWS WAF CreateWebACL API operation.", Operation = new[] {"CreateWebACL"}, SelectReturnType = typeof(Amazon.WAF.Model.CreateWebACLResponse))]
    [AWSCmdletOutput("Amazon.WAF.Model.CreateWebACLResponse",
        "This cmdlet returns an Amazon.WAF.Model.CreateWebACLResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewWAFWebACLCmdlet : AmazonWAFClientCmdlet, IExecutor
    {
        
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
        
        #region Parameter MetricName
        /// <summary>
        /// <para>
        /// <para>A friendly name or description for the metrics for this <code>WebACL</code>.The name
        /// can contain only alphanumeric characters (A-Z, a-z, 0-9), with maximum length 128
        /// and minimum length one. It can't contain whitespace or metric names reserved for AWS
        /// WAF, including "All" and "Default_Action." You can't change <code>MetricName</code>
        /// after you create the <code>WebACL</code>.</para>
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
        public System.String MetricName { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>A friendly name or description of the <a>WebACL</a>. You can't change <code>Name</code>
        /// after you create the <code>WebACL</code>.</para>
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
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.WAF.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter DefaultAction_Type
        /// <summary>
        /// <para>
        /// <para>Specifies how you want AWS WAF to respond to requests that match the settings in a
        /// <code>Rule</code>. Valid settings include the following:</para><ul><li><para><code>ALLOW</code>: AWS WAF allows requests</para></li><li><para><code>BLOCK</code>: AWS WAF blocks requests</para></li><li><para><code>COUNT</code>: AWS WAF increments a counter of the requests that match all of
        /// the conditions in the rule. AWS WAF then continues to inspect the web request based
        /// on the remaining rules in the web ACL. You can't specify <code>COUNT</code> for the
        /// default action for a <code>WebACL</code>.</para></li></ul>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.WAF.WafActionType")]
        public Amazon.WAF.WafActionType DefaultAction_Type { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.WAF.Model.CreateWebACLResponse).
        /// Specifying the name of a property of type Amazon.WAF.Model.CreateWebACLResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.WAF.Model.CreateWebACLResponse, NewWAFWebACLCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ChangeToken = this.ChangeToken;
            #if MODULAR
            if (this.ChangeToken == null && ParameterWasBound(nameof(this.ChangeToken)))
            {
                WriteWarning("You are passing $null as a value for parameter ChangeToken which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DefaultAction_Type = this.DefaultAction_Type;
            #if MODULAR
            if (this.DefaultAction_Type == null && ParameterWasBound(nameof(this.DefaultAction_Type)))
            {
                WriteWarning("You are passing $null as a value for parameter DefaultAction_Type which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MetricName = this.MetricName;
            #if MODULAR
            if (this.MetricName == null && ParameterWasBound(nameof(this.MetricName)))
            {
                WriteWarning("You are passing $null as a value for parameter MetricName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.WAF.Model.Tag>(this.Tag);
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
            var request = new Amazon.WAF.Model.CreateWebACLRequest();
            
            if (cmdletContext.ChangeToken != null)
            {
                request.ChangeToken = cmdletContext.ChangeToken;
            }
            
             // populate DefaultAction
            var requestDefaultActionIsNull = true;
            request.DefaultAction = new Amazon.WAF.Model.WafAction();
            Amazon.WAF.WafActionType requestDefaultAction_defaultAction_Type = null;
            if (cmdletContext.DefaultAction_Type != null)
            {
                requestDefaultAction_defaultAction_Type = cmdletContext.DefaultAction_Type;
            }
            if (requestDefaultAction_defaultAction_Type != null)
            {
                request.DefaultAction.Type = requestDefaultAction_defaultAction_Type;
                requestDefaultActionIsNull = false;
            }
             // determine if request.DefaultAction should be set to null
            if (requestDefaultActionIsNull)
            {
                request.DefaultAction = null;
            }
            if (cmdletContext.MetricName != null)
            {
                request.MetricName = cmdletContext.MetricName;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
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
        
        private Amazon.WAF.Model.CreateWebACLResponse CallAWSServiceOperation(IAmazonWAF client, Amazon.WAF.Model.CreateWebACLRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS WAF", "CreateWebACL");
            try
            {
                #if DESKTOP
                return client.CreateWebACL(request);
                #elif CORECLR
                return client.CreateWebACLAsync(request).GetAwaiter().GetResult();
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
            public Amazon.WAF.WafActionType DefaultAction_Type { get; set; }
            public System.String MetricName { get; set; }
            public System.String Name { get; set; }
            public List<Amazon.WAF.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.WAF.Model.CreateWebACLResponse, NewWAFWebACLCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
