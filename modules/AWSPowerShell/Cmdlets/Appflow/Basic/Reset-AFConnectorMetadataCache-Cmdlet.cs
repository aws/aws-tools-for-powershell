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
using Amazon.Appflow;
using Amazon.Appflow.Model;

namespace Amazon.PowerShell.Cmdlets.AF
{
    /// <summary>
    /// Resets metadata about your connector entities that Amazon AppFlow stored in its cache.
    /// Use this action when you want Amazon AppFlow to return the latest information about
    /// the data that you have in a source application.
    /// 
    ///  
    /// <para>
    /// Amazon AppFlow returns metadata about your entities when you use the ListConnectorEntities
    /// or DescribeConnectorEntities actions. Following these actions, Amazon AppFlow caches
    /// the metadata to reduce the number of API requests that it must send to the source
    /// application. Amazon AppFlow automatically resets the cache once every hour, but you
    /// can use this action when you want to get the latest metadata right away.
    /// </para>
    /// </summary>
    [Cmdlet("Reset", "AFConnectorMetadataCache", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon Appflow ResetConnectorMetadataCache API operation.", Operation = new[] {"ResetConnectorMetadataCache"}, SelectReturnType = typeof(Amazon.Appflow.Model.ResetConnectorMetadataCacheResponse))]
    [AWSCmdletOutput("None or Amazon.Appflow.Model.ResetConnectorMetadataCacheResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.Appflow.Model.ResetConnectorMetadataCacheResponse) be returned by specifying '-Select *'."
    )]
    public partial class ResetAFConnectorMetadataCacheCmdlet : AmazonAppflowClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ApiVersion
        /// <summary>
        /// <para>
        /// <para>The API version that you specified in the connector profile that you’re resetting
        /// cached metadata for. You must use this parameter only if the connector supports multiple
        /// API versions or if the connector type is CustomConnector.</para><para>To look up how many versions a connector supports, use the DescribeConnectors action.
        /// In the response, find the value that Amazon AppFlow returns for the connectorVersion
        /// parameter.</para><para>To look up the connector type, use the DescribeConnectorProfiles action. In the response,
        /// find the value that Amazon AppFlow returns for the connectorType parameter.</para><para>To look up the API version that you specified in a connector profile, use the DescribeConnectorProfiles
        /// action.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ApiVersion { get; set; }
        #endregion
        
        #region Parameter ConnectorEntityName
        /// <summary>
        /// <para>
        /// <para>Use this parameter if you want to reset cached metadata about the details for an individual
        /// entity.</para><para>If you don't include this parameter in your request, Amazon AppFlow only resets cached
        /// metadata about entity names, not entity details.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ConnectorEntityName { get; set; }
        #endregion
        
        #region Parameter ConnectorProfileName
        /// <summary>
        /// <para>
        /// <para>The name of the connector profile that you want to reset cached metadata for.</para><para>You can omit this parameter if you're resetting the cache for any of the following
        /// connectors: Amazon Connect, Amazon EventBridge, Amazon Lookout for Metrics, Amazon
        /// S3, or Upsolver. If you're resetting the cache for any other connector, you must include
        /// this parameter in your request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String ConnectorProfileName { get; set; }
        #endregion
        
        #region Parameter ConnectorType
        /// <summary>
        /// <para>
        /// <para>The type of connector to reset cached metadata for.</para><para>You must include this parameter in your request if you're resetting the cache for
        /// any of the following connectors: Amazon Connect, Amazon EventBridge, Amazon Lookout
        /// for Metrics, Amazon S3, or Upsolver. If you're resetting the cache for any other connector,
        /// you can omit this parameter from your request. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Appflow.ConnectorType")]
        public Amazon.Appflow.ConnectorType ConnectorType { get; set; }
        #endregion
        
        #region Parameter EntitiesPath
        /// <summary>
        /// <para>
        /// <para>Use this parameter only if you’re resetting the cached metadata about a nested entity.
        /// Only some connectors support nested entities. A nested entity is one that has another
        /// entity as a parent. To use this parameter, specify the name of the parent entity.</para><para>To look up the parent-child relationship of entities, you can send a ListConnectorEntities
        /// request that omits the entitiesPath parameter. Amazon AppFlow will return a list of
        /// top-level entities. For each one, it indicates whether the entity has nested entities.
        /// Then, in a subsequent ListConnectorEntities request, you can specify a parent entity
        /// name for the entitiesPath parameter. Amazon AppFlow will return a list of the child
        /// entities for that parent.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EntitiesPath { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Appflow.Model.ResetConnectorMetadataCacheResponse).
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Reset-AFConnectorMetadataCache (ResetConnectorMetadataCache)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Appflow.Model.ResetConnectorMetadataCacheResponse, ResetAFConnectorMetadataCacheCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ApiVersion = this.ApiVersion;
            context.ConnectorEntityName = this.ConnectorEntityName;
            context.ConnectorProfileName = this.ConnectorProfileName;
            context.ConnectorType = this.ConnectorType;
            context.EntitiesPath = this.EntitiesPath;
            
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
            var request = new Amazon.Appflow.Model.ResetConnectorMetadataCacheRequest();
            
            if (cmdletContext.ApiVersion != null)
            {
                request.ApiVersion = cmdletContext.ApiVersion;
            }
            if (cmdletContext.ConnectorEntityName != null)
            {
                request.ConnectorEntityName = cmdletContext.ConnectorEntityName;
            }
            if (cmdletContext.ConnectorProfileName != null)
            {
                request.ConnectorProfileName = cmdletContext.ConnectorProfileName;
            }
            if (cmdletContext.ConnectorType != null)
            {
                request.ConnectorType = cmdletContext.ConnectorType;
            }
            if (cmdletContext.EntitiesPath != null)
            {
                request.EntitiesPath = cmdletContext.EntitiesPath;
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
        
        private Amazon.Appflow.Model.ResetConnectorMetadataCacheResponse CallAWSServiceOperation(IAmazonAppflow client, Amazon.Appflow.Model.ResetConnectorMetadataCacheRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Appflow", "ResetConnectorMetadataCache");
            try
            {
                return client.ResetConnectorMetadataCacheAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ApiVersion { get; set; }
            public System.String ConnectorEntityName { get; set; }
            public System.String ConnectorProfileName { get; set; }
            public Amazon.Appflow.ConnectorType ConnectorType { get; set; }
            public System.String EntitiesPath { get; set; }
            public System.Func<Amazon.Appflow.Model.ResetConnectorMetadataCacheResponse, ResetAFConnectorMetadataCacheCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
