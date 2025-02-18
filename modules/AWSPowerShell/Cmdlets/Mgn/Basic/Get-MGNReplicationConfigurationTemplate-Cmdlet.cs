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
using Amazon.Mgn;
using Amazon.Mgn.Model;

namespace Amazon.PowerShell.Cmdlets.MGN
{
    /// <summary>
    /// Lists all ReplicationConfigurationTemplates, filtered by Source Server IDs.
    /// </summary>
    [Cmdlet("Get", "MGNReplicationConfigurationTemplate")]
    [OutputType("Amazon.Mgn.Model.ReplicationConfigurationTemplate")]
    [AWSCmdlet("Calls the Application Migration Service DescribeReplicationConfigurationTemplates API operation.", Operation = new[] {"DescribeReplicationConfigurationTemplates"}, SelectReturnType = typeof(Amazon.Mgn.Model.DescribeReplicationConfigurationTemplatesResponse))]
    [AWSCmdletOutput("Amazon.Mgn.Model.ReplicationConfigurationTemplate or Amazon.Mgn.Model.DescribeReplicationConfigurationTemplatesResponse",
        "This cmdlet returns a collection of Amazon.Mgn.Model.ReplicationConfigurationTemplate objects.",
        "The service call response (type Amazon.Mgn.Model.DescribeReplicationConfigurationTemplatesResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetMGNReplicationConfigurationTemplateCmdlet : AmazonMgnClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ReplicationConfigurationTemplateIDs
        /// <summary>
        /// <para>
        /// <para>Request to describe Replication Configuration template by template IDs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] ReplicationConfigurationTemplateIDs { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>Request to describe Replication Configuration template by max results.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>Request to describe Replication Configuration template by next token.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Items'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Mgn.Model.DescribeReplicationConfigurationTemplatesResponse).
        /// Specifying the name of a property of type Amazon.Mgn.Model.DescribeReplicationConfigurationTemplatesResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Items";
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
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Mgn.Model.DescribeReplicationConfigurationTemplatesResponse, GetMGNReplicationConfigurationTemplateCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            if (this.ReplicationConfigurationTemplateIDs != null)
            {
                context.ReplicationConfigurationTemplateIDs = new List<System.String>(this.ReplicationConfigurationTemplateIDs);
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
            var request = new Amazon.Mgn.Model.DescribeReplicationConfigurationTemplatesRequest();
            
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.NextToken != null)
            {
                request.NextToken = cmdletContext.NextToken;
            }
            if (cmdletContext.ReplicationConfigurationTemplateIDs != null)
            {
                request.ReplicationConfigurationTemplateIDs = cmdletContext.ReplicationConfigurationTemplateIDs;
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
        
        private Amazon.Mgn.Model.DescribeReplicationConfigurationTemplatesResponse CallAWSServiceOperation(IAmazonMgn client, Amazon.Mgn.Model.DescribeReplicationConfigurationTemplatesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Application Migration Service", "DescribeReplicationConfigurationTemplates");
            try
            {
                return client.DescribeReplicationConfigurationTemplatesAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public List<System.String> ReplicationConfigurationTemplateIDs { get; set; }
            public System.Func<Amazon.Mgn.Model.DescribeReplicationConfigurationTemplatesResponse, GetMGNReplicationConfigurationTemplateCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Items;
        }
        
    }
}
