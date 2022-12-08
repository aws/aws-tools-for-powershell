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
using Amazon.Drs;
using Amazon.Drs.Model;

namespace Amazon.PowerShell.Cmdlets.EDRS
{
    /// <summary>
    /// Lists all ReplicationConfigurationTemplates, filtered by Source Server IDs.
    /// </summary>
    [Cmdlet("Get", "EDRSReplicationConfigurationTemplate")]
    [OutputType("Amazon.Drs.Model.ReplicationConfigurationTemplate")]
    [AWSCmdlet("Calls the Elastic Disaster Recovery Service DescribeReplicationConfigurationTemplates API operation.", Operation = new[] {"DescribeReplicationConfigurationTemplates"}, SelectReturnType = typeof(Amazon.Drs.Model.DescribeReplicationConfigurationTemplatesResponse))]
    [AWSCmdletOutput("Amazon.Drs.Model.ReplicationConfigurationTemplate or Amazon.Drs.Model.DescribeReplicationConfigurationTemplatesResponse",
        "This cmdlet returns a collection of Amazon.Drs.Model.ReplicationConfigurationTemplate objects.",
        "The service call response (type Amazon.Drs.Model.DescribeReplicationConfigurationTemplatesResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetEDRSReplicationConfigurationTemplateCmdlet : AmazonDrsClientCmdlet, IExecutor
    {
        
        #region Parameter IsReplicationConfigurationTemplateIDsSet
        /// <summary>
        /// <para>
        /// This property is set to true if the property <seealso cref="P:Amazon.Drs.Model.DescribeReplicationConfigurationTemplatesRequest.ReplicationConfigurationTemplateIDs" />
        /// is set; false otherwise.
        /// This property can be used to determine if the related property
        /// was returned by a service response or if the related property
        /// should be sent to the service during a service call.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? IsReplicationConfigurationTemplateIDsSet { get; set; }
        #endregion
        
        #region Parameter ReplicationConfigurationTemplateIDs
        /// <summary>
        /// <para>
        /// <para>The IDs of the Replication Configuration Templates to retrieve. An empty list means
        /// all Replication Configuration Templates.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] ReplicationConfigurationTemplateIDs { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>Maximum number of Replication Configuration Templates to retrieve.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>The token of the next Replication Configuration Template to retrieve.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Items'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Drs.Model.DescribeReplicationConfigurationTemplatesResponse).
        /// Specifying the name of a property of type Amazon.Drs.Model.DescribeReplicationConfigurationTemplatesResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Items";
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Drs.Model.DescribeReplicationConfigurationTemplatesResponse, GetEDRSReplicationConfigurationTemplateCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            if (this.ReplicationConfigurationTemplateIDs != null)
            {
                context.ReplicationConfigurationTemplateIDs = new List<System.String>(this.ReplicationConfigurationTemplateIDs);
            }
            context.IsReplicationConfigurationTemplateIDsSet = this.IsReplicationConfigurationTemplateIDsSet;
            if (!ParameterWasBound(nameof(this.IsReplicationConfigurationTemplateIDsSet)) && this.ReplicationConfigurationTemplateIDs != null)
            {
                context.IsReplicationConfigurationTemplateIDsSet = true;
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
            var request = new Amazon.Drs.Model.DescribeReplicationConfigurationTemplatesRequest();
            
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
            if (cmdletContext.IsReplicationConfigurationTemplateIDsSet != null)
            {
                request.IsReplicationConfigurationTemplateIDsSet = cmdletContext.IsReplicationConfigurationTemplateIDsSet.Value;
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
        
        private Amazon.Drs.Model.DescribeReplicationConfigurationTemplatesResponse CallAWSServiceOperation(IAmazonDrs client, Amazon.Drs.Model.DescribeReplicationConfigurationTemplatesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Elastic Disaster Recovery Service", "DescribeReplicationConfigurationTemplates");
            try
            {
                #if DESKTOP
                return client.DescribeReplicationConfigurationTemplates(request);
                #elif CORECLR
                return client.DescribeReplicationConfigurationTemplatesAsync(request).GetAwaiter().GetResult();
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
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public List<System.String> ReplicationConfigurationTemplateIDs { get; set; }
            public System.Boolean? IsReplicationConfigurationTemplateIDsSet { get; set; }
            public System.Func<Amazon.Drs.Model.DescribeReplicationConfigurationTemplatesResponse, GetEDRSReplicationConfigurationTemplateCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Items;
        }
        
    }
}
