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
using Amazon.ElastiCache;
using Amazon.ElastiCache.Model;

namespace Amazon.PowerShell.Cmdlets.EC
{
    /// <summary>
    /// Lists all tags currently on a named resource.
    /// 
    ///  
    /// <para>
    ///  A tag is a key-value pair where the key and value are case-sensitive. You can use
    /// tags to categorize and track all your ElastiCache resources, with the exception of
    /// global replication group. When you add or remove tags on replication groups, those
    /// actions will be replicated to all nodes in the replication group. For more information,
    /// see <a href="http://docs.aws.amazon.com/AmazonElastiCache/latest/red-ug/IAM.ResourceLevelPermissions.html">Resource-level
    /// permissions</a>.
    /// </para><para>
    /// If the cluster is not in the <i>available</i> state, <c>ListTagsForResource</c> returns
    /// an error.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "ECTag")]
    [OutputType("Amazon.ElastiCache.Model.Tag")]
    [AWSCmdlet("Calls the Amazon ElastiCache ListTagsForResource API operation.", Operation = new[] {"ListTagsForResource"}, SelectReturnType = typeof(Amazon.ElastiCache.Model.ListTagsForResourceResponse))]
    [AWSCmdletOutput("Amazon.ElastiCache.Model.Tag or Amazon.ElastiCache.Model.ListTagsForResourceResponse",
        "This cmdlet returns a collection of Amazon.ElastiCache.Model.Tag objects.",
        "The service call response (type Amazon.ElastiCache.Model.ListTagsForResourceResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetECTagCmdlet : AmazonElastiCacheClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ResourceName
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the resource for which you want the list of tags,
        /// for example <c>arn:aws:elasticache:us-west-2:0123456789:cluster:myCluster</c> or <c>arn:aws:elasticache:us-west-2:0123456789:snapshot:mySnapshot</c>.</para><para>For more information about ARNs, see <a href="https://docs.aws.amazon.com/general/latest/gr/aws-arns-and-namespaces.html">Amazon
        /// Resource Names (ARNs) and Amazon Web Services Service Namespaces</a>.</para>
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
        public System.String ResourceName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'TagList'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ElastiCache.Model.ListTagsForResourceResponse).
        /// Specifying the name of a property of type Amazon.ElastiCache.Model.ListTagsForResourceResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "TagList";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ResourceName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ResourceName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ResourceName' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ElastiCache.Model.ListTagsForResourceResponse, GetECTagCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ResourceName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ResourceName = this.ResourceName;
            #if MODULAR
            if (this.ResourceName == null && ParameterWasBound(nameof(this.ResourceName)))
            {
                WriteWarning("You are passing $null as a value for parameter ResourceName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.ElastiCache.Model.ListTagsForResourceRequest();
            
            if (cmdletContext.ResourceName != null)
            {
                request.ResourceName = cmdletContext.ResourceName;
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
        
        private Amazon.ElastiCache.Model.ListTagsForResourceResponse CallAWSServiceOperation(IAmazonElastiCache client, Amazon.ElastiCache.Model.ListTagsForResourceRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon ElastiCache", "ListTagsForResource");
            try
            {
                #if DESKTOP
                return client.ListTagsForResource(request);
                #elif CORECLR
                return client.ListTagsForResourceAsync(request).GetAwaiter().GetResult();
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
            public System.String ResourceName { get; set; }
            public System.Func<Amazon.ElastiCache.Model.ListTagsForResourceResponse, GetECTagCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.TagList;
        }
        
    }
}
