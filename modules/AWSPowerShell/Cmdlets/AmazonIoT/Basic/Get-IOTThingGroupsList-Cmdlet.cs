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
using Amazon.IoT;
using Amazon.IoT.Model;

namespace Amazon.PowerShell.Cmdlets.IOT
{
    /// <summary>
    /// List the thing groups in your account.
    /// </summary>
    [Cmdlet("Get", "IOTThingGroupsList")]
    [OutputType("Amazon.IoT.Model.GroupNameAndArn")]
    [AWSCmdlet("Calls the AWS IoT ListThingGroups API operation.", Operation = new[] {"ListThingGroups"})]
    [AWSCmdletOutput("Amazon.IoT.Model.GroupNameAndArn",
        "This cmdlet returns a collection of GroupNameAndArn objects.",
        "The service call response (type Amazon.IoT.Model.ListThingGroupsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack.",
        "Additionally, the following properties are added as Note properties to the service response type instance for the cmdlet entry in the $AWSHistory stack: NextToken (type System.String)"
    )]
    public partial class GetIOTThingGroupsListCmdlet : AmazonIoTClientCmdlet, IExecutor
    {
        
        #region Parameter NamePrefixFilter
        /// <summary>
        /// <para>
        /// <para>A filter that limits the results to those with the specified name prefix.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String NamePrefixFilter { get; set; }
        #endregion
        
        #region Parameter ParentGroup
        /// <summary>
        /// <para>
        /// <para>A filter that limits the results to those with the specified parent group.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ParentGroup { get; set; }
        #endregion
        
        #region Parameter Recursive
        /// <summary>
        /// <para>
        /// <para>If true, return child groups as well.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean Recursive { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of results to return at one time.</para>
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
        /// <para>The token used to get the next set of results, or <b>null</b> if there are no additional
        /// results.</para>
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
            
            if (ParameterWasBound("MaxResult"))
                context.MaxResults = this.MaxResult;
            context.NamePrefixFilter = this.NamePrefixFilter;
            context.NextToken = this.NextToken;
            context.ParentGroup = this.ParentGroup;
            if (ParameterWasBound("Recursive"))
                context.Recursive = this.Recursive;
            
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
            var request = new Amazon.IoT.Model.ListThingGroupsRequest();
            
            if (cmdletContext.MaxResults != null)
            {
                request.MaxResults = AutoIterationHelpers.ConvertEmitLimitToServiceTypeInt32(cmdletContext.MaxResults.Value);
            }
            if (cmdletContext.NamePrefixFilter != null)
            {
                request.NamePrefixFilter = cmdletContext.NamePrefixFilter;
            }
            if (cmdletContext.NextToken != null)
            {
                request.NextToken = cmdletContext.NextToken;
            }
            if (cmdletContext.ParentGroup != null)
            {
                request.ParentGroup = cmdletContext.ParentGroup;
            }
            if (cmdletContext.Recursive != null)
            {
                request.Recursive = cmdletContext.Recursive.Value;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.ThingGroups;
                notes = new Dictionary<string, object>();
                notes["NextToken"] = response.NextToken;
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response,
                    Notes = notes
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
        
        private Amazon.IoT.Model.ListThingGroupsResponse CallAWSServiceOperation(IAmazonIoT client, Amazon.IoT.Model.ListThingGroupsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS IoT", "ListThingGroups");
            try
            {
                #if DESKTOP
                return client.ListThingGroups(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.ListThingGroupsAsync(request);
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
            public int? MaxResults { get; set; }
            public System.String NamePrefixFilter { get; set; }
            public System.String NextToken { get; set; }
            public System.String ParentGroup { get; set; }
            public System.Boolean? Recursive { get; set; }
        }
        
    }
}
