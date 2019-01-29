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
using Amazon.SimpleWorkflow;
using Amazon.SimpleWorkflow.Model;

namespace Amazon.PowerShell.Cmdlets.SWF
{
    /// <summary>
    /// Returns information about the specified activity type. This includes configuration
    /// settings provided when the type was registered and other general information about
    /// the type.
    /// 
    ///  
    /// <para><b>Access Control</b></para><para>
    /// You can use IAM policies to control this action's access to Amazon SWF resources as
    /// follows:
    /// </para><ul><li><para>
    /// Use a <code>Resource</code> element with the domain name to limit the action to only
    /// specified domains.
    /// </para></li><li><para>
    /// Use an <code>Action</code> element to allow or deny permission to call this action.
    /// </para></li><li><para>
    /// Constrain the following parameters by using a <code>Condition</code> element with
    /// the appropriate keys.
    /// </para><ul><li><para><code>activityType.name</code>: String constraint. The key is <code>swf:activityType.name</code>.
    /// </para></li><li><para><code>activityType.version</code>: String constraint. The key is <code>swf:activityType.version</code>.
    /// </para></li></ul></li></ul><para>
    /// If the caller doesn't have sufficient permissions to invoke the action, or the parameter
    /// values fall outside the specified constraints, the action fails. The associated event
    /// attribute's <code>cause</code> parameter is set to <code>OPERATION_NOT_PERMITTED</code>.
    /// For details and example IAM policies, see <a href="http://docs.aws.amazon.com/amazonswf/latest/developerguide/swf-dev-iam.html">Using
    /// IAM to Manage Access to Amazon SWF Workflows</a> in the <i>Amazon SWF Developer Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "SWFActivityType")]
    [OutputType("Amazon.SimpleWorkflow.Model.ActivityTypeDetail")]
    [AWSCmdlet("Calls the AWS Simple Workflow Service DescribeActivityType API operation.", Operation = new[] {"DescribeActivityType"})]
    [AWSCmdletOutput("Amazon.SimpleWorkflow.Model.ActivityTypeDetail",
        "This cmdlet returns a Amazon.SimpleWorkflow.Model.ActivityTypeDetail object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetSWFActivityTypeCmdlet : AmazonSimpleWorkflowClientCmdlet, IExecutor
    {
        
        #region Parameter Domain
        /// <summary>
        /// <para>
        /// <para>The name of the domain in which the activity type is registered.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Domain { get; set; }
        #endregion
        
        #region Parameter ActivityType_Name
        /// <summary>
        /// <para>
        /// <para>The name of this activity.</para><note><para>The combination of activity type name and version must be unique within a domain.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String ActivityType_Name { get; set; }
        #endregion
        
        #region Parameter ActivityType_Version
        /// <summary>
        /// <para>
        /// <para>The version of this activity.</para><note><para>The combination of activity type name and version must be unique with in a domain.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ActivityType_Version { get; set; }
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
            
            context.ActivityType_Name = this.ActivityType_Name;
            context.ActivityType_Version = this.ActivityType_Version;
            context.Domain = this.Domain;
            
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
            var request = new Amazon.SimpleWorkflow.Model.DescribeActivityTypeRequest();
            
            
             // populate ActivityType
            bool requestActivityTypeIsNull = true;
            request.ActivityType = new Amazon.SimpleWorkflow.Model.ActivityType();
            System.String requestActivityType_activityType_Name = null;
            if (cmdletContext.ActivityType_Name != null)
            {
                requestActivityType_activityType_Name = cmdletContext.ActivityType_Name;
            }
            if (requestActivityType_activityType_Name != null)
            {
                request.ActivityType.Name = requestActivityType_activityType_Name;
                requestActivityTypeIsNull = false;
            }
            System.String requestActivityType_activityType_Version = null;
            if (cmdletContext.ActivityType_Version != null)
            {
                requestActivityType_activityType_Version = cmdletContext.ActivityType_Version;
            }
            if (requestActivityType_activityType_Version != null)
            {
                request.ActivityType.Version = requestActivityType_activityType_Version;
                requestActivityTypeIsNull = false;
            }
             // determine if request.ActivityType should be set to null
            if (requestActivityTypeIsNull)
            {
                request.ActivityType = null;
            }
            if (cmdletContext.Domain != null)
            {
                request.Domain = cmdletContext.Domain;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response;
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
        
        private Amazon.SimpleWorkflow.Model.DescribeActivityTypeResponse CallAWSServiceOperation(IAmazonSimpleWorkflow client, Amazon.SimpleWorkflow.Model.DescribeActivityTypeRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Simple Workflow Service", "DescribeActivityType");
            try
            {
                #if DESKTOP
                return client.DescribeActivityType(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.DescribeActivityTypeAsync(request);
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
            public System.String ActivityType_Name { get; set; }
            public System.String ActivityType_Version { get; set; }
            public System.String Domain { get; set; }
        }
        
    }
}
