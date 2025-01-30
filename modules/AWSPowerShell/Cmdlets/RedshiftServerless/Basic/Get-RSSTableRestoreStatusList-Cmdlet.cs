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
    /// Returns information about an array of <c>TableRestoreStatus</c> objects.
    /// </summary>
    [Cmdlet("Get", "RSSTableRestoreStatusList")]
    [OutputType("Amazon.RedshiftServerless.Model.TableRestoreStatus")]
    [AWSCmdlet("Calls the Redshift Serverless ListTableRestoreStatus API operation.", Operation = new[] {"ListTableRestoreStatus"}, SelectReturnType = typeof(Amazon.RedshiftServerless.Model.ListTableRestoreStatusResponse))]
    [AWSCmdletOutput("Amazon.RedshiftServerless.Model.TableRestoreStatus or Amazon.RedshiftServerless.Model.ListTableRestoreStatusResponse",
        "This cmdlet returns a collection of Amazon.RedshiftServerless.Model.TableRestoreStatus objects.",
        "The service call response (type Amazon.RedshiftServerless.Model.ListTableRestoreStatusResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetRSSTableRestoreStatusListCmdlet : AmazonRedshiftServerlessClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter NamespaceName
        /// <summary>
        /// <para>
        /// <para>The namespace from which to list all of the statuses of <c>RestoreTableFromSnapshot</c>
        /// operations .</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NamespaceName { get; set; }
        #endregion
        
        #region Parameter WorkgroupName
        /// <summary>
        /// <para>
        /// <para>The workgroup from which to list all of the statuses of <c>RestoreTableFromSnapshot</c>
        /// operations.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String WorkgroupName { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>An optional parameter that specifies the maximum number of results to return. You
        /// can use nextToken to display the next page of results.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>If your initial <c>ListTableRestoreStatus</c> operation returns a nextToken, you can
        /// include the returned <c>nextToken</c> in following <c>ListTableRestoreStatus</c> operations.
        /// This will return results on the next page.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'TableRestoreStatuses'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.RedshiftServerless.Model.ListTableRestoreStatusResponse).
        /// Specifying the name of a property of type Amazon.RedshiftServerless.Model.ListTableRestoreStatusResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "TableRestoreStatuses";
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
                context.Select = CreateSelectDelegate<Amazon.RedshiftServerless.Model.ListTableRestoreStatusResponse, GetRSSTableRestoreStatusListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.MaxResult = this.MaxResult;
            context.NamespaceName = this.NamespaceName;
            context.NextToken = this.NextToken;
            context.WorkgroupName = this.WorkgroupName;
            
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
            var request = new Amazon.RedshiftServerless.Model.ListTableRestoreStatusRequest();
            
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.NamespaceName != null)
            {
                request.NamespaceName = cmdletContext.NamespaceName;
            }
            if (cmdletContext.NextToken != null)
            {
                request.NextToken = cmdletContext.NextToken;
            }
            if (cmdletContext.WorkgroupName != null)
            {
                request.WorkgroupName = cmdletContext.WorkgroupName;
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
        
        private Amazon.RedshiftServerless.Model.ListTableRestoreStatusResponse CallAWSServiceOperation(IAmazonRedshiftServerless client, Amazon.RedshiftServerless.Model.ListTableRestoreStatusRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Redshift Serverless", "ListTableRestoreStatus");
            try
            {
                #if DESKTOP
                return client.ListTableRestoreStatus(request);
                #elif CORECLR
                return client.ListTableRestoreStatusAsync(request).GetAwaiter().GetResult();
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
            public System.String NamespaceName { get; set; }
            public System.String NextToken { get; set; }
            public System.String WorkgroupName { get; set; }
            public System.Func<Amazon.RedshiftServerless.Model.ListTableRestoreStatusResponse, GetRSSTableRestoreStatusListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.TableRestoreStatuses;
        }
        
    }
}
