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
using Amazon.EC2;
using Amazon.EC2.Model;

namespace Amazon.PowerShell.Cmdlets.EC2
{
    /// <summary>
    /// Describes the modifications made to your Reserved Instances. If no parameter is specified,
    /// information about all your Reserved Instances modification requests is returned. If
    /// a modification ID is specified, only information about the specific modification is
    /// returned.
    /// 
    ///  
    /// <para>
    /// For more information, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/ri-modifying.html">Modifying
    /// Reserved Instances</a> in the <i>Amazon EC2 User Guide</i>.
    /// </para><br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "EC2ReservedInstancesModification")]
    [OutputType("Amazon.EC2.Model.ReservedInstancesModification")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) DescribeReservedInstancesModifications API operation.", Operation = new[] {"DescribeReservedInstancesModifications"}, SelectReturnType = typeof(Amazon.EC2.Model.DescribeReservedInstancesModificationsResponse), LegacyAlias="Get-EC2ReservedInstancesModifications")]
    [AWSCmdletOutput("Amazon.EC2.Model.ReservedInstancesModification or Amazon.EC2.Model.DescribeReservedInstancesModificationsResponse",
        "This cmdlet returns a collection of Amazon.EC2.Model.ReservedInstancesModification objects.",
        "The service call response (type Amazon.EC2.Model.DescribeReservedInstancesModificationsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetEC2ReservedInstancesModificationCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        #region Parameter Filter
        /// <summary>
        /// <para>
        /// <para>One or more filters.</para><ul><li><para><code>client-token</code> - The idempotency token for the modification request.</para></li><li><para><code>create-date</code> - The time when the modification request was created.</para></li><li><para><code>effective-date</code> - The time when the modification becomes effective.</para></li><li><para><code>modification-result.reserved-instances-id</code> - The ID for the Reserved
        /// Instances created as part of the modification request. This ID is only available when
        /// the status of the modification is <code>fulfilled</code>.</para></li><li><para><code>modification-result.target-configuration.availability-zone</code> - The Availability
        /// Zone for the new Reserved Instances.</para></li><li><para><code>modification-result.target-configuration.instance-count </code> - The number
        /// of new Reserved Instances.</para></li><li><para><code>modification-result.target-configuration.instance-type</code> - The instance
        /// type of the new Reserved Instances.</para></li><li><para><code>modification-result.target-configuration.platform</code> - The network platform
        /// of the new Reserved Instances (<code>EC2-Classic</code> | <code>EC2-VPC</code>).</para></li><li><para><code>reserved-instances-id</code> - The ID of the Reserved Instances modified.</para></li><li><para><code>reserved-instances-modification-id</code> - The ID of the modification request.</para></li><li><para><code>status</code> - The status of the Reserved Instances modification request (<code>processing</code>
        /// | <code>fulfilled</code> | <code>failed</code>).</para></li><li><para><code>status-message</code> - The reason for the status.</para></li><li><para><code>update-date</code> - The time when the modification request was last updated.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filters")]
        public Amazon.EC2.Model.Filter[] Filter { get; set; }
        #endregion
        
        #region Parameter ReservedInstancesModificationId
        /// <summary>
        /// <para>
        /// <para>IDs for the submitted modification request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ReservedInstancesModificationIds")]
        public System.String[] ReservedInstancesModificationId { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>The token to retrieve the next page of results.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> This parameter is only used if you are manually controlling output pagination of the service API call.
        /// <br/>In order to manually control output pagination, use '-NextToken $null' for the first call and '-NextToken $AWSHistory.LastServiceResponse.NextToken' for subsequent calls.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ReservedInstancesModifications'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.DescribeReservedInstancesModificationsResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.DescribeReservedInstancesModificationsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ReservedInstancesModifications";
        #endregion
        
        #region Parameter NoAutoIteration
        /// <summary>
        /// By default the cmdlet will auto-iterate and retrieve all results to the pipeline by performing multiple
        /// service calls. If set, the cmdlet will retrieve only the next 'page' of results using the value of NextToken
        /// as the start point.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter NoAutoIteration { get; set; }
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
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.DescribeReservedInstancesModificationsResponse, GetEC2ReservedInstancesModificationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.Filter != null)
            {
                context.Filter = new List<Amazon.EC2.Model.Filter>(this.Filter);
            }
            context.NextToken = this.NextToken;
            if (this.ReservedInstancesModificationId != null)
            {
                context.ReservedInstancesModificationId = new List<System.String>(this.ReservedInstancesModificationId);
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
            var useParameterSelect = this.Select.StartsWith("^");
            
            // create request and set iteration invariants
            var request = new Amazon.EC2.Model.DescribeReservedInstancesModificationsRequest();
            
            if (cmdletContext.Filter != null)
            {
                request.Filters = cmdletContext.Filter;
            }
            if (cmdletContext.ReservedInstancesModificationId != null)
            {
                request.ReservedInstancesModificationIds = cmdletContext.ReservedInstancesModificationId;
            }
            
            // Initialize loop variant and commence piping
            var _nextToken = cmdletContext.NextToken;
            var _userControllingPaging = this.NoAutoIteration.IsPresent || ParameterWasBound(nameof(this.NextToken));
            
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            do
            {
                request.NextToken = _nextToken;
                
                CmdletOutput output;
                
                try
                {
                    
                    var response = CallAWSServiceOperation(client, request);
                    
                    object pipelineOutput = null;
                    if (!useParameterSelect)
                    {
                        pipelineOutput = cmdletContext.Select(response, this);
                    }
                    output = new CmdletOutput
                    {
                        PipelineOutput = pipelineOutput,
                        ServiceResponse = response
                    };
                    
                    _nextToken = response.NextToken;
                }
                catch (Exception e)
                {
                    output = new CmdletOutput { ErrorResponse = e };
                }
                
                ProcessOutput(output);
                
            } while (!_userControllingPaging && AutoIterationHelpers.HasValue(_nextToken));
            
            if (useParameterSelect)
            {
                WriteObject(cmdletContext.Select(null, this));
            }
            
            
            return null;
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.EC2.Model.DescribeReservedInstancesModificationsResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.DescribeReservedInstancesModificationsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "DescribeReservedInstancesModifications");
            try
            {
                #if DESKTOP
                return client.DescribeReservedInstancesModifications(request);
                #elif CORECLR
                return client.DescribeReservedInstancesModificationsAsync(request).GetAwaiter().GetResult();
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
            public List<Amazon.EC2.Model.Filter> Filter { get; set; }
            public System.String NextToken { get; set; }
            public List<System.String> ReservedInstancesModificationId { get; set; }
            public System.Func<Amazon.EC2.Model.DescribeReservedInstancesModificationsResponse, GetEC2ReservedInstancesModificationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ReservedInstancesModifications;
        }
        
    }
}
