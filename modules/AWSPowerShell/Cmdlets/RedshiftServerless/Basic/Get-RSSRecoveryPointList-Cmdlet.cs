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
using Amazon.RedshiftServerless;
using Amazon.RedshiftServerless.Model;

namespace Amazon.PowerShell.Cmdlets.RSS
{
    /// <summary>
    /// Returns an array of recovery points.
    /// </summary>
    [Cmdlet("Get", "RSSRecoveryPointList")]
    [OutputType("Amazon.RedshiftServerless.Model.RecoveryPoint")]
    [AWSCmdlet("Calls the Redshift Serverless ListRecoveryPoints API operation.", Operation = new[] {"ListRecoveryPoints"}, SelectReturnType = typeof(Amazon.RedshiftServerless.Model.ListRecoveryPointsResponse))]
    [AWSCmdletOutput("Amazon.RedshiftServerless.Model.RecoveryPoint or Amazon.RedshiftServerless.Model.ListRecoveryPointsResponse",
        "This cmdlet returns a collection of Amazon.RedshiftServerless.Model.RecoveryPoint objects.",
        "The service call response (type Amazon.RedshiftServerless.Model.ListRecoveryPointsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetRSSRecoveryPointListCmdlet : AmazonRedshiftServerlessClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter EndTime
        /// <summary>
        /// <para>
        /// <para>The time when creation of the recovery point finished.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? EndTime { get; set; }
        #endregion
        
        #region Parameter NamespaceArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the namespace from which to list recovery points.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NamespaceArn { get; set; }
        #endregion
        
        #region Parameter NamespaceName
        /// <summary>
        /// <para>
        /// <para>The name of the namespace to list recovery points for.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String NamespaceName { get; set; }
        #endregion
        
        #region Parameter StartTime
        /// <summary>
        /// <para>
        /// <para>The time when the recovery point's creation was initiated.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? StartTime { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>An optional parameter that specifies the maximum number of results to return. You
        /// can use <c>nextToken</c> to display the next page of results.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>If your initial <c>ListRecoveryPoints</c> operation returns a <c>nextToken</c>, you
        /// can include the returned <c>nextToken</c> in following <c>ListRecoveryPoints</c> operations,
        /// which returns results in the next page.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'RecoveryPoints'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.RedshiftServerless.Model.ListRecoveryPointsResponse).
        /// Specifying the name of a property of type Amazon.RedshiftServerless.Model.ListRecoveryPointsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "RecoveryPoints";
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
                context.Select = CreateSelectDelegate<Amazon.RedshiftServerless.Model.ListRecoveryPointsResponse, GetRSSRecoveryPointListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.EndTime = this.EndTime;
            context.MaxResult = this.MaxResult;
            context.NamespaceArn = this.NamespaceArn;
            context.NamespaceName = this.NamespaceName;
            context.NextToken = this.NextToken;
            context.StartTime = this.StartTime;
            
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
            var request = new Amazon.RedshiftServerless.Model.ListRecoveryPointsRequest();
            
            if (cmdletContext.EndTime != null)
            {
                request.EndTime = cmdletContext.EndTime.Value;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.NamespaceArn != null)
            {
                request.NamespaceArn = cmdletContext.NamespaceArn;
            }
            if (cmdletContext.NamespaceName != null)
            {
                request.NamespaceName = cmdletContext.NamespaceName;
            }
            if (cmdletContext.NextToken != null)
            {
                request.NextToken = cmdletContext.NextToken;
            }
            if (cmdletContext.StartTime != null)
            {
                request.StartTime = cmdletContext.StartTime.Value;
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
        
        private Amazon.RedshiftServerless.Model.ListRecoveryPointsResponse CallAWSServiceOperation(IAmazonRedshiftServerless client, Amazon.RedshiftServerless.Model.ListRecoveryPointsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Redshift Serverless", "ListRecoveryPoints");
            try
            {
                #if DESKTOP
                return client.ListRecoveryPoints(request);
                #elif CORECLR
                return client.ListRecoveryPointsAsync(request).GetAwaiter().GetResult();
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
            public System.DateTime? EndTime { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NamespaceArn { get; set; }
            public System.String NamespaceName { get; set; }
            public System.String NextToken { get; set; }
            public System.DateTime? StartTime { get; set; }
            public System.Func<Amazon.RedshiftServerless.Model.ListRecoveryPointsResponse, GetRSSRecoveryPointListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.RecoveryPoints;
        }
        
    }
}
