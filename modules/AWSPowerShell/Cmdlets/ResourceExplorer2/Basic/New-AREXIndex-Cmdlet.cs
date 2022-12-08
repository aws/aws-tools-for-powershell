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
    /// Turns on Amazon Web Services Resource Explorer in the Amazon Web Services Region in
    /// which you called this operation by creating an index. Resource Explorer begins discovering
    /// the resources in this Region and stores the details about the resources in the index
    /// so that they can be queried by using the <a>Search</a> operation. You can create only
    /// one index in a Region.
    /// 
    ///  <note><para>
    /// This operation creates only a <i>local</i> index. To promote the local index in one
    /// Amazon Web Services Region into the aggregator index for the Amazon Web Services account,
    /// use the <a>UpdateIndexType</a> operation. For more information, see <a href="https://docs.aws.amazon.com/resource-explorer/latest/userguide/manage-aggregator-region.html">Turning
    /// on cross-Region search by creating an aggregator index</a> in the <i>Amazon Web Services
    /// Resource Explorer User Guide</i>.
    /// </para></note><para>
    /// For more details about what happens when you turn on Resource Explorer in an Amazon
    /// Web Services Region, see <a href="https://docs.aws.amazon.com/resource-explorer/latest/userguide/manage-service-activate.html">Turn
    /// on Resource Explorer to index your resources in an Amazon Web Services Region</a>
    /// in the <i>Amazon Web Services Resource Explorer User Guide</i>.
    /// </para><para>
    /// If this is the first Amazon Web Services Region in which you've created an index for
    /// Resource Explorer, then this operation also <a href="https://docs.aws.amazon.com/arexug/mainline/security_iam_service-linked-roles.html">creates
    /// a service-linked role</a> in your Amazon Web Services account that allows Resource
    /// Explorer to enumerate your resources to populate the index.
    /// </para><ul><li><para><b>Action</b>: <code>resource-explorer-2:CreateIndex</code></para><para><b>Resource</b>: The ARN of the index (as it will exist after the operation completes)
    /// in the Amazon Web Services Region and account in which you're trying to create the
    /// index. Use the wildcard character (<code>*</code>) at the end of the string to match
    /// the eventual UUID. For example, the following <code>Resource</code> element restricts
    /// the role or user to creating an index in only the <code>us-east-2</code> Region of
    /// the specified account.
    /// </para><para><code>"Resource": "arn:aws:resource-explorer-2:us-west-2:<i>&lt;account-id&gt;</i>:index/*"</code></para><para>
    /// Alternatively, you can use <code>"Resource": "*"</code> to allow the role or user
    /// to create an index in any Region.
    /// </para></li><li><para><b>Action</b>: <code>iam:CreateServiceLinkedRole</code></para><para><b>Resource</b>: No specific resource (*). 
    /// </para><para>
    /// This permission is required only the first time you create an index to turn on Resource
    /// Explorer in the account. Resource Explorer uses this to create the <a href="https://docs.aws.amazon.com/resource-explorer/latest/userguide/security_iam_service-linked-roles.html">service-linked
    /// role needed to index the resources in your account</a>. Resource Explorer uses the
    /// same service-linked role for all additional indexes you create afterwards.
    /// </para></li></ul>
    /// </summary>
    [Cmdlet("New", "AREXIndex", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ResourceExplorer2.Model.CreateIndexResponse")]
    [AWSCmdlet("Calls the AWS Resource Explorer CreateIndex API operation.", Operation = new[] {"CreateIndex"}, SelectReturnType = typeof(Amazon.ResourceExplorer2.Model.CreateIndexResponse))]
    [AWSCmdletOutput("Amazon.ResourceExplorer2.Model.CreateIndexResponse",
        "This cmdlet returns an Amazon.ResourceExplorer2.Model.CreateIndexResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewAREXIndexCmdlet : AmazonResourceExplorer2ClientCmdlet, IExecutor
    {
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The specified tags are attached only to the index created in this Amazon Web Services
        /// Region. The tags aren't attached to any of the resources listed in the index.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>This value helps ensure idempotency. Resource Explorer uses this value to prevent
        /// the accidental creation of duplicate versions. We recommend that you generate a <a href="https://wikipedia.org/wiki/Universally_unique_identifier">UUID-type value</a>
        /// to ensure the uniqueness of your views.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ResourceExplorer2.Model.CreateIndexResponse).
        /// Specifying the name of a property of type Amazon.ResourceExplorer2.Model.CreateIndexResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-AREXIndex (CreateIndex)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ResourceExplorer2.Model.CreateIndexResponse, NewAREXIndexCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientToken = this.ClientToken;
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (String)(this.Tag[hashKey]));
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
            var request = new Amazon.ResourceExplorer2.Model.CreateIndexRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
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
        
        private Amazon.ResourceExplorer2.Model.CreateIndexResponse CallAWSServiceOperation(IAmazonResourceExplorer2 client, Amazon.ResourceExplorer2.Model.CreateIndexRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Resource Explorer", "CreateIndex");
            try
            {
                #if DESKTOP
                return client.CreateIndex(request);
                #elif CORECLR
                return client.CreateIndexAsync(request).GetAwaiter().GetResult();
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
            public System.String ClientToken { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.ResourceExplorer2.Model.CreateIndexResponse, NewAREXIndexCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
