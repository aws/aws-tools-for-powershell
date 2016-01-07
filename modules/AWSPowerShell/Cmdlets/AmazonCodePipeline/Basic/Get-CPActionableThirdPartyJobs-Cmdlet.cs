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
using Amazon.CodePipeline;
using Amazon.CodePipeline.Model;

namespace Amazon.PowerShell.Cmdlets.CP
{
    /// <summary>
    /// Determines whether there are any third party jobs for a job worker to act on. Only
    /// used for partner actions.
    /// 
    ///  <important><para>
    /// When this API is called, AWS CodePipeline returns temporary credentials for the Amazon
    /// S3 bucket used to store artifacts for the pipeline, if the action requires access
    /// to that Amazon S3 bucket for input or output artifacts.
    /// </para></important>
    /// </summary>
    [Cmdlet("Get", "CPActionableThirdPartyJobs")]
    [OutputType("Amazon.CodePipeline.Model.ThirdPartyJob")]
    [AWSCmdlet("Invokes the PollForThirdPartyJobs operation against AWS CodePipeline.", Operation = new[] {"PollForThirdPartyJobs"})]
    [AWSCmdletOutput("Amazon.CodePipeline.Model.ThirdPartyJob",
        "This cmdlet returns a collection of ThirdPartyJob objects.",
        "The service call response (type Amazon.CodePipeline.Model.PollForThirdPartyJobsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class GetCPActionableThirdPartyJobsCmdlet : AmazonCodePipelineClientCmdlet, IExecutor
    {
        
        #region Parameter ActionTypeId_Category
        /// <summary>
        /// <para>
        /// <para>A category defines what kind of action can be taken in the stage, and constrains the
        /// provider type for the action. Valid categories are limited to one of the values below.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.CodePipeline.ActionCategory")]
        public Amazon.CodePipeline.ActionCategory ActionTypeId_Category { get; set; }
        #endregion
        
        #region Parameter MaxBatchSize
        /// <summary>
        /// <para>
        /// <para>The maximum number of jobs to return in a poll for jobs call.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 MaxBatchSize { get; set; }
        #endregion
        
        #region Parameter ActionTypeId_Provider
        /// <summary>
        /// <para>
        /// <para>The provider of the service being called by the action. Valid providers are determined
        /// by the action category. For example, an action in the Deploy category type might have
        /// a provider of AWS CodeDeploy, which would be specified as CodeDeploy.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ActionTypeId_Provider { get; set; }
        #endregion
        
        #region Parameter ActionTypeId_Version
        /// <summary>
        /// <para>
        /// <para>A string that identifies the action type. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ActionTypeId_Version { get; set; }
        #endregion
        
        #region Parameter ActionTypeId_Owner
        /// <summary>
        /// <para>
        /// <para>The creator of the action being called. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.CodePipeline.ActionOwner")]
        public Amazon.CodePipeline.ActionOwner ActionTypeId_Owner { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.ActionTypeId_Category = this.ActionTypeId_Category;
            context.ActionTypeId_Owner = this.ActionTypeId_Owner;
            context.ActionTypeId_Provider = this.ActionTypeId_Provider;
            context.ActionTypeId_Version = this.ActionTypeId_Version;
            if (ParameterWasBound("MaxBatchSize"))
                context.MaxBatchSize = this.MaxBatchSize;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.CodePipeline.Model.PollForThirdPartyJobsRequest();
            
            
             // populate ActionTypeId
            bool requestActionTypeIdIsNull = true;
            request.ActionTypeId = new Amazon.CodePipeline.Model.ActionTypeId();
            Amazon.CodePipeline.ActionCategory requestActionTypeId_actionTypeId_Category = null;
            if (cmdletContext.ActionTypeId_Category != null)
            {
                requestActionTypeId_actionTypeId_Category = cmdletContext.ActionTypeId_Category;
            }
            if (requestActionTypeId_actionTypeId_Category != null)
            {
                request.ActionTypeId.Category = requestActionTypeId_actionTypeId_Category;
                requestActionTypeIdIsNull = false;
            }
            Amazon.CodePipeline.ActionOwner requestActionTypeId_actionTypeId_Owner = null;
            if (cmdletContext.ActionTypeId_Owner != null)
            {
                requestActionTypeId_actionTypeId_Owner = cmdletContext.ActionTypeId_Owner;
            }
            if (requestActionTypeId_actionTypeId_Owner != null)
            {
                request.ActionTypeId.Owner = requestActionTypeId_actionTypeId_Owner;
                requestActionTypeIdIsNull = false;
            }
            System.String requestActionTypeId_actionTypeId_Provider = null;
            if (cmdletContext.ActionTypeId_Provider != null)
            {
                requestActionTypeId_actionTypeId_Provider = cmdletContext.ActionTypeId_Provider;
            }
            if (requestActionTypeId_actionTypeId_Provider != null)
            {
                request.ActionTypeId.Provider = requestActionTypeId_actionTypeId_Provider;
                requestActionTypeIdIsNull = false;
            }
            System.String requestActionTypeId_actionTypeId_Version = null;
            if (cmdletContext.ActionTypeId_Version != null)
            {
                requestActionTypeId_actionTypeId_Version = cmdletContext.ActionTypeId_Version;
            }
            if (requestActionTypeId_actionTypeId_Version != null)
            {
                request.ActionTypeId.Version = requestActionTypeId_actionTypeId_Version;
                requestActionTypeIdIsNull = false;
            }
             // determine if request.ActionTypeId should be set to null
            if (requestActionTypeIdIsNull)
            {
                request.ActionTypeId = null;
            }
            if (cmdletContext.MaxBatchSize != null)
            {
                request.MaxBatchSize = cmdletContext.MaxBatchSize.Value;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.PollForThirdPartyJobs(request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.Jobs;
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
        
        
        internal class CmdletContext : ExecutorContext
        {
            public Amazon.CodePipeline.ActionCategory ActionTypeId_Category { get; set; }
            public Amazon.CodePipeline.ActionOwner ActionTypeId_Owner { get; set; }
            public System.String ActionTypeId_Provider { get; set; }
            public System.String ActionTypeId_Version { get; set; }
            public System.Int32? MaxBatchSize { get; set; }
        }
        
    }
}
