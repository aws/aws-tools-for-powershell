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
using Amazon.ElasticMapReduce;
using Amazon.ElasticMapReduce.Model;

namespace Amazon.PowerShell.Cmdlets.EMR
{
    /// <summary>
    /// Provides information for all active Amazon EC2 instances and Amazon EC2 instances
    /// terminated in the last 30 days, up to a maximum of 2,000. Amazon EC2 instances in
    /// any of the following states are considered active: AWAITING_FULFILLMENT, PROVISIONING,
    /// BOOTSTRAPPING, RUNNING.<br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "EMRInstanceList")]
    [OutputType("Amazon.ElasticMapReduce.Model.Instance")]
    [AWSCmdlet("Calls the Amazon Elastic MapReduce ListInstances API operation.", Operation = new[] {"ListInstances"}, SelectReturnType = typeof(Amazon.ElasticMapReduce.Model.ListInstancesResponse), LegacyAlias="Get-EMRInstances")]
    [AWSCmdletOutput("Amazon.ElasticMapReduce.Model.Instance or Amazon.ElasticMapReduce.Model.ListInstancesResponse",
        "This cmdlet returns a collection of Amazon.ElasticMapReduce.Model.Instance objects.",
        "The service call response (type Amazon.ElasticMapReduce.Model.ListInstancesResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetEMRInstanceListCmdlet : AmazonElasticMapReduceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ClusterId
        /// <summary>
        /// <para>
        /// <para>The identifier of the cluster for which to list the instances.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String ClusterId { get; set; }
        #endregion
        
        #region Parameter InstanceFleetId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the instance fleet.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String InstanceFleetId { get; set; }
        #endregion
        
        #region Parameter InstanceFleetType
        /// <summary>
        /// <para>
        /// <para>The node type of the instance fleet. For example MASTER, CORE, or TASK.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.ElasticMapReduce.InstanceFleetType")]
        public Amazon.ElasticMapReduce.InstanceFleetType InstanceFleetType { get; set; }
        #endregion
        
        #region Parameter InstanceGroupId
        /// <summary>
        /// <para>
        /// <para>The identifier of the instance group for which to list the instances.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String InstanceGroupId { get; set; }
        #endregion
        
        #region Parameter InstanceGroupType
        /// <summary>
        /// <para>
        /// <para>The type of instance group for which to list the instances.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 2, ValueFromPipelineByPropertyName = true)]
        [Alias("InstanceGroupTypes")]
        public System.String[] InstanceGroupType { get; set; }
        #endregion
        
        #region Parameter InstanceState
        /// <summary>
        /// <para>
        /// <para>A list of instance states that will filter the instances returned with this request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InstanceStates")]
        public System.String[] InstanceState { get; set; }
        #endregion
        
        #region Parameter Marker
        /// <summary>
        /// <para>
        /// <para>The pagination token that indicates the next set of results to retrieve.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> This parameter is only used if you are manually controlling output pagination of the service API call.
        /// <br/>'Marker' is only returned by the cmdlet when '-Select *' is specified. In order to manually control output pagination, set '-Marker' to null for the first call then set the 'Marker' using the same property output from the previous call for subsequent calls.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("NextToken")]
        public System.String Marker { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Instances'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ElasticMapReduce.Model.ListInstancesResponse).
        /// Specifying the name of a property of type Amazon.ElasticMapReduce.Model.ListInstancesResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Instances";
        #endregion
        
        #region Parameter NoAutoIteration
        /// <summary>
        /// By default the cmdlet will auto-iterate and retrieve all results to the pipeline by performing multiple
        /// service calls. If set, the cmdlet will retrieve only the next 'page' of results using the value of Marker
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
                context.Select = CreateSelectDelegate<Amazon.ElasticMapReduce.Model.ListInstancesResponse, GetEMRInstanceListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClusterId = this.ClusterId;
            #if MODULAR
            if (this.ClusterId == null && ParameterWasBound(nameof(this.ClusterId)))
            {
                WriteWarning("You are passing $null as a value for parameter ClusterId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.InstanceFleetId = this.InstanceFleetId;
            context.InstanceFleetType = this.InstanceFleetType;
            context.InstanceGroupId = this.InstanceGroupId;
            if (this.InstanceGroupType != null)
            {
                context.InstanceGroupType = new List<System.String>(this.InstanceGroupType);
            }
            if (this.InstanceState != null)
            {
                context.InstanceState = new List<System.String>(this.InstanceState);
            }
            context.Marker = this.Marker;
            
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
            var request = new Amazon.ElasticMapReduce.Model.ListInstancesRequest();
            
            if (cmdletContext.ClusterId != null)
            {
                request.ClusterId = cmdletContext.ClusterId;
            }
            if (cmdletContext.InstanceFleetId != null)
            {
                request.InstanceFleetId = cmdletContext.InstanceFleetId;
            }
            if (cmdletContext.InstanceFleetType != null)
            {
                request.InstanceFleetType = cmdletContext.InstanceFleetType;
            }
            if (cmdletContext.InstanceGroupId != null)
            {
                request.InstanceGroupId = cmdletContext.InstanceGroupId;
            }
            if (cmdletContext.InstanceGroupType != null)
            {
                request.InstanceGroupTypes = cmdletContext.InstanceGroupType;
            }
            if (cmdletContext.InstanceState != null)
            {
                request.InstanceStates = cmdletContext.InstanceState;
            }
            
            // Initialize loop variant and commence piping
            var _nextToken = cmdletContext.Marker;
            var _userControllingPaging = this.NoAutoIteration.IsPresent || ParameterWasBound(nameof(this.Marker));
            
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            do
            {
                request.Marker = _nextToken;
                
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
                    
                    _nextToken = response.Marker;
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
        
        private Amazon.ElasticMapReduce.Model.ListInstancesResponse CallAWSServiceOperation(IAmazonElasticMapReduce client, Amazon.ElasticMapReduce.Model.ListInstancesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic MapReduce", "ListInstances");
            try
            {
                #if DESKTOP
                return client.ListInstances(request);
                #elif CORECLR
                return client.ListInstancesAsync(request).GetAwaiter().GetResult();
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
            public System.String ClusterId { get; set; }
            public System.String InstanceFleetId { get; set; }
            public Amazon.ElasticMapReduce.InstanceFleetType InstanceFleetType { get; set; }
            public System.String InstanceGroupId { get; set; }
            public List<System.String> InstanceGroupType { get; set; }
            public List<System.String> InstanceState { get; set; }
            public System.String Marker { get; set; }
            public System.Func<Amazon.ElasticMapReduce.Model.ListInstancesResponse, GetEMRInstanceListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Instances;
        }
        
    }
}
