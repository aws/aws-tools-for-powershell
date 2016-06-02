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
using Amazon.CodeDeploy;
using Amazon.CodeDeploy.Model;

namespace Amazon.PowerShell.Cmdlets.CD
{
    /// <summary>
    /// Gets a list of names for one or more on-premises instances.
    /// 
    ///  
    /// <para>
    /// Unless otherwise specified, both registered and deregistered on-premises instance
    /// names will be listed. To list only registered or deregistered on-premises instance
    /// names, use the registration status parameter.
    /// </para><br/><br/>This operation automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output.
    /// </summary>
    [Cmdlet("Get", "CDOnPremiseInstanceList")]
    [OutputType("System.String")]
    [AWSCmdlet("Invokes the ListOnPremisesInstances operation against AWS CodeDeploy.", Operation = new[] {"ListOnPremisesInstances"})]
    [AWSCmdletOutput("System.String",
        "This cmdlet returns a collection of String objects.",
        "The service call response (type Amazon.CodeDeploy.Model.ListOnPremisesInstancesResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack.",
        "Additionally, the following properties are added as Note properties to the service response type instance for the cmdlet entry in the $AWSHistory stack: NextToken (type System.String)"
    )]
    public class GetCDOnPremiseInstanceListCmdlet : AmazonCodeDeployClientCmdlet, IExecutor
    {
        
        #region Parameter RegistrationStatus
        /// <summary>
        /// <para>
        /// <para>The registration status of the on-premises instances:</para><ul><li>Deregistered: Include deregistered on-premises instances in the resulting
        /// list.</li><li>Registered: Include registered on-premises instances in the resulting
        /// list.</li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.CodeDeploy.RegistrationStatus")]
        public Amazon.CodeDeploy.RegistrationStatus RegistrationStatus { get; set; }
        #endregion
        
        #region Parameter TagFilter
        /// <summary>
        /// <para>
        /// <para>The on-premises instance tags that will be used to restrict the corresponding on-premises
        /// instance names returned.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("TagFilters")]
        public Amazon.CodeDeploy.Model.TagFilter[] TagFilter { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>An identifier returned from the previous list on-premises instances call. It can be
        /// used to return the next set of on-premises instances in the list.</para>
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
            
            context.NextToken = this.NextToken;
            context.RegistrationStatus = this.RegistrationStatus;
            if (this.TagFilter != null)
            {
                context.TagFilters = new List<Amazon.CodeDeploy.Model.TagFilter>(this.TagFilter);
            }
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            
            // create request and set iteration invariants
            var request = new Amazon.CodeDeploy.Model.ListOnPremisesInstancesRequest();
            
            if (cmdletContext.RegistrationStatus != null)
            {
                request.RegistrationStatus = cmdletContext.RegistrationStatus;
            }
            if (cmdletContext.TagFilters != null)
            {
                request.TagFilters = cmdletContext.TagFilters;
            }
            
            // Initialize loop variant and commence piping
            System.String _nextMarker = null;
            bool _userControllingPaging = false;
            if (AutoIterationHelpers.HasValue(cmdletContext.NextToken))
            {
                _nextMarker = cmdletContext.NextToken;
                _userControllingPaging = true;
            }
            
            try
            {
                do
                {
                    request.NextToken = _nextMarker;
                    
                    var client = Client ?? CreateClient(context.Credentials, context.Region);
                    CmdletOutput output;
                    
                    try
                    {
                        
                        var response = CallAWSServiceOperation(client, request);
                        
                        Dictionary<string, object> notes = null;
                        object pipelineOutput = response.InstanceNames;
                        notes = new Dictionary<string, object>();
                        notes["NextToken"] = response.NextToken;
                        output = new CmdletOutput
                        {
                            PipelineOutput = pipelineOutput,
                            ServiceResponse = response,
                            Notes = notes
                        };
                        if (_userControllingPaging)
                        {
                            int _receivedThisCall = response.InstanceNames.Count;
                            WriteProgressRecord("Retrieving", string.Format("Retrieved {0} records starting from marker '{1}'", _receivedThisCall, request.NextToken));
                        }
                        
                        _nextMarker = response.NextToken;
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
        
        private static Amazon.CodeDeploy.Model.ListOnPremisesInstancesResponse CallAWSServiceOperation(IAmazonCodeDeploy client, Amazon.CodeDeploy.Model.ListOnPremisesInstancesRequest request)
        {
            return client.ListOnPremisesInstances(request);
        }
        
        #endregion
        
        internal class CmdletContext : ExecutorContext
        {
            public System.String NextToken { get; set; }
            public Amazon.CodeDeploy.RegistrationStatus RegistrationStatus { get; set; }
            public List<Amazon.CodeDeploy.Model.TagFilter> TagFilters { get; set; }
        }
        
    }
}
