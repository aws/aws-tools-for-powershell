/*******************************************************************************
 *  Copyright 2012-2015 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// Provides information about the cluster instances that Amazon EMR provisions on behalf
    /// of a user when it creates the cluster. For example, this operation indicates when
    /// the EC2 instances reach the Ready state, when instances become available to Amazon
    /// EMR to use for jobs, and the IP addresses for cluster instances, etc.<br/><br/>This operation automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output.
    /// </summary>
    [Cmdlet("Get", "EMRInstances")]
    [OutputType("Amazon.ElasticMapReduce.Model.Instance")]
    [AWSCmdlet("Invokes the ListInstances operation against Amazon Elastic MapReduce.", Operation = new[] {"ListInstances"})]
    [AWSCmdletOutput("Amazon.ElasticMapReduce.Model.Instance",
        "This cmdlet returns a collection of Instance objects.",
        "The service call response (type Amazon.ElasticMapReduce.Model.ListInstancesResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack.",
        "Additionally, the following properties are added as Note properties to the service response type instance for the cmdlet entry in the $AWSHistory stack: Marker (type System.String)"
    )]
    public class GetEMRInstancesCmdlet : AmazonElasticMapReduceClientCmdlet, IExecutor
    {
        
        #region Parameter ClusterId
        /// <summary>
        /// <para>
        /// <para>The identifier of the cluster for which to list the instances.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        public System.String ClusterId { get; set; }
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
        [System.Management.Automation.Parameter(Position = 2)]
        [Alias("InstanceGroupTypes")]
        public System.String[] InstanceGroupType { get; set; }
        #endregion
        
        #region Parameter InstanceState
        /// <summary>
        /// <para>
        /// <para>A list of instance states that will filter the instances returned with this request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("InstanceStates")]
        public System.String[] InstanceState { get; set; }
        #endregion
        
        #region Parameter Marker
        /// <summary>
        /// <para>
        /// <para>The pagination token that indicates the next set of results to retrieve.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("NextToken")]
        public System.String Marker { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.ClusterId = this.ClusterId;
            context.InstanceGroupId = this.InstanceGroupId;
            if (this.InstanceGroupType != null)
            {
                context.InstanceGroupTypes = new List<System.String>(this.InstanceGroupType);
            }
            if (this.InstanceState != null)
            {
                context.InstanceStates = new List<System.String>(this.InstanceState);
            }
            context.Marker = this.Marker;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            
            // create request and set iteration invariants
            var request = new Amazon.ElasticMapReduce.Model.ListInstancesRequest();
            
            if (cmdletContext.ClusterId != null)
            {
                request.ClusterId = cmdletContext.ClusterId;
            }
            if (cmdletContext.InstanceGroupId != null)
            {
                request.InstanceGroupId = cmdletContext.InstanceGroupId;
            }
            if (cmdletContext.InstanceGroupTypes != null)
            {
                request.InstanceGroupTypes = cmdletContext.InstanceGroupTypes;
            }
            if (cmdletContext.InstanceStates != null)
            {
                request.InstanceStates = cmdletContext.InstanceStates;
            }
            
            // Initialize loop variant and commence piping
            System.String _nextMarker = null;
            bool _userControllingPaging = false;
            if (AutoIterationHelpers.HasValue(cmdletContext.Marker))
            {
                _nextMarker = cmdletContext.Marker;
                _userControllingPaging = true;
            }
            
            try
            {
                do
                {
                    request.Marker = _nextMarker;
                    
                    var client = Client ?? CreateClient(context.Credentials, context.Region);
                    CmdletOutput output;
                    
                    try
                    {
                        
                        var response = CallAWSServiceOperation(client, request);
                        
                        Dictionary<string, object> notes = null;
                        object pipelineOutput = response.Instances;
                        notes = new Dictionary<string, object>();
                        notes["Marker"] = response.Marker;
                        output = new CmdletOutput
                        {
                            PipelineOutput = pipelineOutput,
                            ServiceResponse = response,
                            Notes = notes
                        };
                        if (_userControllingPaging)
                        {
                            int _receivedThisCall = response.Instances.Count;
                            WriteProgressRecord("Retrieving", string.Format("Retrieved {0} records starting from marker '{1}'", _receivedThisCall, request.Marker));
                        }
                        
                        _nextMarker = response.Marker;
                    }
                    catch (Exception e)
                    {
                        output = new CmdletOutput { ErrorResponse = e };
                    }
                    
                    ProcessOutput(output);
                    
                } while (AutoIterationHelpers.HasValue(_nextMarker));
            }
            finally
            {
                if (_userControllingPaging)
                {
                    WriteProgressCompleteRecord("Retrieving", "Retrieved records");
                }
            }
            
            return null;
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private static Amazon.ElasticMapReduce.Model.ListInstancesResponse CallAWSServiceOperation(IAmazonElasticMapReduce client, Amazon.ElasticMapReduce.Model.ListInstancesRequest request)
        {
            return client.ListInstances(request);
        }
        
        #endregion
        
        internal class CmdletContext : ExecutorContext
        {
            public System.String ClusterId { get; set; }
            public System.String InstanceGroupId { get; set; }
            public List<System.String> InstanceGroupTypes { get; set; }
            public List<System.String> InstanceStates { get; set; }
            public System.String Marker { get; set; }
        }
        
    }
}
