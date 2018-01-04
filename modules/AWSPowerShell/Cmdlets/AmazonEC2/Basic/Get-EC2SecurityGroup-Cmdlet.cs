/*******************************************************************************
 *  Copyright 2012-2018 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// Describes one or more of your security groups.
    /// 
    ///  
    /// <para>
    /// A security group is for use with instances either in the EC2-Classic platform or in
    /// a specific VPC. For more information, see <a href="http://docs.aws.amazon.com/AWSEC2/latest/UserGuide/using-network-security.html">Amazon
    /// EC2 Security Groups</a> in the <i>Amazon Elastic Compute Cloud User Guide</i> and
    /// <a href="http://docs.aws.amazon.com/AmazonVPC/latest/UserGuide/VPC_SecurityGroups.html">Security
    /// Groups for Your VPC</a> in the <i>Amazon Virtual Private Cloud User Guide</i>.
    /// </para><br/><br/>This operation automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output.
    /// </summary>
    [Cmdlet("Get", "EC2SecurityGroup")]
    [OutputType("Amazon.EC2.Model.SecurityGroup")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud DescribeSecurityGroups API operation.", Operation = new[] {"DescribeSecurityGroups"})]
    [AWSCmdletOutput("Amazon.EC2.Model.SecurityGroup",
        "This cmdlet returns a collection of SecurityGroup objects.",
        "The service call response (type Amazon.EC2.Model.DescribeSecurityGroupsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack.",
        "Additionally, the following properties are added as Note properties to the service response type instance for the cmdlet entry in the $AWSHistory stack: NextToken (type System.String)"
    )]
    public partial class GetEC2SecurityGroupCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        #region Parameter Filter
        /// <summary>
        /// <para>
        /// <para>One or more filters. If using multiple filters for rules, the results include security
        /// groups for which any combination of rules - not necessarily a single rule - match
        /// all filters.</para><ul><li><para><code>description</code> - The description of the security group.</para></li><li><para><code>egress.ip-permission.cidr</code> - An IPv4 CIDR block for an outbound security
        /// group rule.</para></li><li><para><code>egress.ip-permission.from-port</code> - For an outbound rule, the start of
        /// port range for the TCP and UDP protocols, or an ICMP type number.</para></li><li><para><code>egress.ip-permission.group-id</code> - The ID of a security group that has
        /// been referenced in an outbound security group rule.</para></li><li><para><code>egress.ip-permission.group-name</code> - The name of a security group that
        /// has been referenced in an outbound security group rule.</para></li><li><para><code>egress.ip-permission.ipv6-cidr</code> - An IPv6 CIDR block for an outbound
        /// security group rule.</para></li><li><para><code>egress.ip-permission.prefix-list-id</code> - The ID (prefix) of the AWS service
        /// to which a security group rule allows outbound access.</para></li><li><para><code>egress.ip-permission.protocol</code> - The IP protocol for an outbound security
        /// group rule (<code>tcp</code> | <code>udp</code> | <code>icmp</code> or a protocol
        /// number).</para></li><li><para><code>egress.ip-permission.to-port</code> - For an outbound rule, the end of port
        /// range for the TCP and UDP protocols, or an ICMP code.</para></li><li><para><code>egress.ip-permission.user-id</code> - The ID of an AWS account that has been
        /// referenced in an outbound security group rule.</para></li><li><para><code>group-id</code> - The ID of the security group. </para></li><li><para><code>group-name</code> - The name of the security group.</para></li><li><para><code>ip-permission.cidr</code> - An IPv4 CIDR block for an inbound security group
        /// rule.</para></li><li><para><code>ip-permission.from-port</code> - For an inbound rule, the start of port range
        /// for the TCP and UDP protocols, or an ICMP type number.</para></li><li><para><code>ip-permission.group-id</code> - The ID of a security group that has been referenced
        /// in an inbound security group rule.</para></li><li><para><code>ip-permission.group-name</code> - The name of a security group that has been
        /// referenced in an inbound security group rule.</para></li><li><para><code>ip-permission.ipv6-cidr</code> - An IPv6 CIDR block for an inbound security
        /// group rule.</para></li><li><para><code>ip-permission.prefix-list-id</code> - The ID (prefix) of the AWS service from
        /// which a security group rule allows inbound access.</para></li><li><para><code>ip-permission.protocol</code> - The IP protocol for an inbound security group
        /// rule (<code>tcp</code> | <code>udp</code> | <code>icmp</code> or a protocol number).</para></li><li><para><code>ip-permission.to-port</code> - For an inbound rule, the end of port range for
        /// the TCP and UDP protocols, or an ICMP code.</para></li><li><para><code>ip-permission.user-id</code> - The ID of an AWS account that has been referenced
        /// in an inbound security group rule.</para></li><li><para><code>owner-id</code> - The AWS account ID of the owner of the security group.</para></li><li><para><code>tag-key</code> - The key of a tag assigned to the security group.</para></li><li><para><code>tag-value</code> - The value of a tag assigned to the security group.</para></li><li><para><code>vpc-id</code> - The ID of the VPC specified when the security group was created.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1)]
        [Alias("Filters")]
        public Amazon.EC2.Model.Filter[] Filter { get; set; }
        #endregion
        
        #region Parameter GroupId
        /// <summary>
        /// <para>
        /// <para>One or more security group IDs. Required for security groups in a nondefault VPC.</para><para>Default: Describes all your security groups.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        [Alias("GroupIds")]
        public System.String[] GroupId { get; set; }
        #endregion
        
        #region Parameter GroupName
        /// <summary>
        /// <para>
        /// <para>[EC2-Classic and default VPC only] One or more security group names. You can specify
        /// either the security group name or the security group ID. For security groups in a
        /// nondefault VPC, use the <code>group-name</code> filter to describe security groups
        /// by name.</para><para>Default: Describes all your security groups.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("GroupNames")]
        public System.String[] GroupName { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of results to return in a single call. To retrieve the remaining
        /// results, make another request with the returned <code>NextToken</code> value. This
        /// value can be between 5 and 1000.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> This parameter is only used if you are manually controlling output pagination of the service API call.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MaxItems","MaxResults")]
        public int MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>The token to request the next page of results.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> This parameter is only used if you are manually controlling output pagination of the service API call.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String NextToken { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (this.Filter != null)
            {
                context.Filters = new List<Amazon.EC2.Model.Filter>(this.Filter);
            }
            if (this.GroupId != null)
            {
                context.GroupIds = new List<System.String>(this.GroupId);
            }
            if (this.GroupName != null)
            {
                context.GroupNames = new List<System.String>(this.GroupName);
            }
            if (ParameterWasBound("MaxResult"))
                context.MaxResults = this.MaxResult;
            context.NextToken = this.NextToken;
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            
            // create request and set iteration invariants
            var request = new Amazon.EC2.Model.DescribeSecurityGroupsRequest();
            if (cmdletContext.Filters != null)
            {
                request.Filters = cmdletContext.Filters;
            }
            if (cmdletContext.GroupIds != null)
            {
                request.GroupIds = cmdletContext.GroupIds;
            }
            if (cmdletContext.GroupNames != null)
            {
                request.GroupNames = cmdletContext.GroupNames;
            }
            
            // Initialize loop variants and commence piping
            System.String _nextMarker = null;
            int? _emitLimit = null;
            int _retrievedSoFar = 0;
            if (AutoIterationHelpers.HasValue(cmdletContext.NextToken))
            {
                _nextMarker = cmdletContext.NextToken;
            }
            if (AutoIterationHelpers.HasValue(cmdletContext.MaxResults))
            {
                _emitLimit = cmdletContext.MaxResults;
            }
            bool _userControllingPaging = AutoIterationHelpers.HasValue(cmdletContext.NextToken) || AutoIterationHelpers.HasValue(cmdletContext.MaxResults);
            bool _continueIteration = true;
            
            try
            {
                do
                {
                    request.NextToken = _nextMarker;
                    if (AutoIterationHelpers.HasValue(_emitLimit))
                    {
                        request.MaxResults = AutoIterationHelpers.ConvertEmitLimitToInt32(_emitLimit.Value);
                    }
                    
                    var client = Client ?? CreateClient(context.Credentials, context.Region);
                    CmdletOutput output;
                    
                    try
                    {
                        
                        var response = CallAWSServiceOperation(client, request);
                        Dictionary<string, object> notes = null;
                        object pipelineOutput = response.SecurityGroups;
                        notes = new Dictionary<string, object>();
                        notes["NextToken"] = response.NextToken;
                        output = new CmdletOutput
                        {
                            PipelineOutput = pipelineOutput,
                            ServiceResponse = response,
                            Notes = notes
                        };
                        int _receivedThisCall = response.SecurityGroups.Count;
                        if (_userControllingPaging)
                        {
                            WriteProgressRecord("Retrieving", string.Format("Retrieved {0} records starting from marker '{1}'", _receivedThisCall, request.NextToken));
                        }
                        
                        _nextMarker = response.NextToken;
                        
                        _retrievedSoFar += _receivedThisCall;
                        if (AutoIterationHelpers.HasValue(_emitLimit) && (_retrievedSoFar == 0 || _retrievedSoFar >= _emitLimit.Value))
                        {
                            _continueIteration = false;
                        }
                    }
                    catch (Exception e)
                    {
                        output = new CmdletOutput { ErrorResponse = e };
                    }
                    
                    ProcessOutput(output);
                } while (_continueIteration && AutoIterationHelpers.HasValue(_nextMarker));
                
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
        
        private Amazon.EC2.Model.DescribeSecurityGroupsResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.DescribeSecurityGroupsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud", "DescribeSecurityGroups");
            try
            {
                #if DESKTOP
                return client.DescribeSecurityGroups(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.DescribeSecurityGroupsAsync(request);
                return task.Result;
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
            public List<Amazon.EC2.Model.Filter> Filters { get; set; }
            public List<System.String> GroupIds { get; set; }
            public List<System.String> GroupNames { get; set; }
            public int? MaxResults { get; set; }
            public System.String NextToken { get; set; }
        }
        
    }
}
