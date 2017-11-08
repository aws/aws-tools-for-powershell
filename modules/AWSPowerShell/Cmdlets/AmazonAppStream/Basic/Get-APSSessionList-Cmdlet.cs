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
using Amazon.AppStream;
using Amazon.AppStream.Model;

namespace Amazon.PowerShell.Cmdlets.APS
{
    /// <summary>
    /// Describes the streaming sessions for the specified stack and fleet. If a user ID is
    /// provided, only the streaming sessions for only that user are returned. If an authentication
    /// type is not provided, the default is to authenticate users using a streaming URL.<br/><br/>This operation automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output.
    /// </summary>
    [Cmdlet("Get", "APSSessionList")]
    [OutputType("Amazon.AppStream.Model.Session")]
    [AWSCmdlet("Calls the AWS AppStream DescribeSessions API operation.", Operation = new[] {"DescribeSessions"})]
    [AWSCmdletOutput("Amazon.AppStream.Model.Session",
        "This cmdlet returns a collection of Session objects.",
        "The service call response (type Amazon.AppStream.Model.DescribeSessionsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack.",
        "Additionally, the following properties are added as Note properties to the service response type instance for the cmdlet entry in the $AWSHistory stack: NextToken (type System.String)"
    )]
    public partial class GetAPSSessionListCmdlet : AmazonAppStreamClientCmdlet, IExecutor
    {
        
        #region Parameter AuthenticationType
        /// <summary>
        /// <para>
        /// <para>The authentication method. Specify <code>API</code> for a user authenticated using
        /// a streaming URL or <code>SAML</code> for a SAML federated user. The default is to
        /// authenticate users using a streaming URL.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.AppStream.AuthenticationType")]
        public Amazon.AppStream.AuthenticationType AuthenticationType { get; set; }
        #endregion
        
        #region Parameter FleetName
        /// <summary>
        /// <para>
        /// <para>The name of the fleet.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String FleetName { get; set; }
        #endregion
        
        #region Parameter StackName
        /// <summary>
        /// <para>
        /// <para>The name of the stack.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String StackName { get; set; }
        #endregion
        
        #region Parameter UserId
        /// <summary>
        /// <para>
        /// <para>The user ID.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String UserId { get; set; }
        #endregion
        
        #region Parameter Limit
        /// <summary>
        /// <para>
        /// <para>The size of each page of results. The default value is 20 and the maximum value is
        /// 50.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 Limit { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>The pagination token to use to retrieve the next page of results for this operation.
        /// If this value is null, it retrieves the first page.</para>
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
            
            context.AuthenticationType = this.AuthenticationType;
            context.FleetName = this.FleetName;
            if (ParameterWasBound("Limit"))
                context.Limit = this.Limit;
            context.NextToken = this.NextToken;
            context.StackName = this.StackName;
            context.UserId = this.UserId;
            
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
            var request = new Amazon.AppStream.Model.DescribeSessionsRequest();
            
            if (cmdletContext.AuthenticationType != null)
            {
                request.AuthenticationType = cmdletContext.AuthenticationType;
            }
            if (cmdletContext.FleetName != null)
            {
                request.FleetName = cmdletContext.FleetName;
            }
            if (cmdletContext.Limit != null)
            {
                request.Limit = cmdletContext.Limit.Value;
            }
            if (cmdletContext.StackName != null)
            {
                request.StackName = cmdletContext.StackName;
            }
            if (cmdletContext.UserId != null)
            {
                request.UserId = cmdletContext.UserId;
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
                        object pipelineOutput = response.Sessions;
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
                            int _receivedThisCall = response.Sessions.Count;
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
        
        private Amazon.AppStream.Model.DescribeSessionsResponse CallAWSServiceOperation(IAmazonAppStream client, Amazon.AppStream.Model.DescribeSessionsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS AppStream", "DescribeSessions");
            try
            {
                #if DESKTOP
                return client.DescribeSessions(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.DescribeSessionsAsync(request);
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
            public Amazon.AppStream.AuthenticationType AuthenticationType { get; set; }
            public System.String FleetName { get; set; }
            public System.Int32? Limit { get; set; }
            public System.String NextToken { get; set; }
            public System.String StackName { get; set; }
            public System.String UserId { get; set; }
        }
        
    }
}
