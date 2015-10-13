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
using Amazon.ElasticBeanstalk;
using Amazon.ElasticBeanstalk.Model;

namespace Amazon.PowerShell.Cmdlets.EB
{
    /// <summary>
    /// Swaps the CNAMEs of two environments.
    /// </summary>
    [Cmdlet("Set", "EBEnvironmentCNAME", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None","System.String")]
    [AWSCmdlet("Invokes the SwapEnvironmentCNAMEs operation against AWS Elastic Beanstalk.", Operation = new[] {"SwapEnvironmentCNAMEs"})]
    [AWSCmdletOutput("None or System.String",
        "When you use the PassThru parameter, this cmdlet outputs the value supplied to the SourceEnvironmentId parameter. Otherwise, this cmdlet does not return any output. " +
        "The service response (type Amazon.ElasticBeanstalk.Model.SwapEnvironmentCNAMEsResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class SetEBEnvironmentCNAMECmdlet : AmazonElasticBeanstalkClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// <para> The ID of the destination environment. </para><para> Condition: You must specify at least the <code>DestinationEnvironmentID</code> or
        /// the <code>DestinationEnvironmentName</code>. You may also specify both. You must specify
        /// the <code>SourceEnvironmentId</code> with the <code>DestinationEnvironmentId</code>.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 2)]
        public System.String DestinationEnvironmentId { get; set; }
        
        /// <summary>
        /// <para>
        /// <para> The name of the destination environment. </para><para> Condition: You must specify at least the <code>DestinationEnvironmentID</code> or
        /// the <code>DestinationEnvironmentName</code>. You may also specify both. You must specify
        /// the <code>SourceEnvironmentName</code> with the <code>DestinationEnvironmentName</code>.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 3)]
        public System.String DestinationEnvironmentName { get; set; }
        
        /// <summary>
        /// <para>
        /// <para> The ID of the source environment. </para><para> Condition: You must specify at least the <code>SourceEnvironmentID</code> or the
        /// <code>SourceEnvironmentName</code>. You may also specify both. If you specify the
        /// <code>SourceEnvironmentId</code>, you must specify the <code>DestinationEnvironmentId</code>.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String SourceEnvironmentId { get; set; }
        
        /// <summary>
        /// <para>
        /// <para> The name of the source environment. </para><para> Condition: You must specify at least the <code>SourceEnvironmentID</code> or the
        /// <code>SourceEnvironmentName</code>. You may also specify both. If you specify the
        /// <code>SourceEnvironmentName</code>, you must specify the <code>DestinationEnvironmentName</code>.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1)]
        public System.String SourceEnvironmentName { get; set; }
        
        /// <summary>
        /// Returns the value passed to the SourceEnvironmentId parameter.
        /// By default, this cmdlet does not generate any output.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter PassThru { get; set; }
        
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("SourceEnvironmentId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Set-EBEnvironmentCNAME (SwapEnvironmentCNAMEs)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.DestinationEnvironmentId = this.DestinationEnvironmentId;
            context.DestinationEnvironmentName = this.DestinationEnvironmentName;
            context.SourceEnvironmentId = this.SourceEnvironmentId;
            context.SourceEnvironmentName = this.SourceEnvironmentName;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.ElasticBeanstalk.Model.SwapEnvironmentCNAMEsRequest();
            
            if (cmdletContext.DestinationEnvironmentId != null)
            {
                request.DestinationEnvironmentId = cmdletContext.DestinationEnvironmentId;
            }
            if (cmdletContext.DestinationEnvironmentName != null)
            {
                request.DestinationEnvironmentName = cmdletContext.DestinationEnvironmentName;
            }
            if (cmdletContext.SourceEnvironmentId != null)
            {
                request.SourceEnvironmentId = cmdletContext.SourceEnvironmentId;
            }
            if (cmdletContext.SourceEnvironmentName != null)
            {
                request.SourceEnvironmentName = cmdletContext.SourceEnvironmentName;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.SwapEnvironmentCNAMEs(request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = null;
                if (this.PassThru.IsPresent)
                    pipelineOutput = this.SourceEnvironmentId;
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
            public System.String DestinationEnvironmentId { get; set; }
            public System.String DestinationEnvironmentName { get; set; }
            public System.String SourceEnvironmentId { get; set; }
            public System.String SourceEnvironmentName { get; set; }
        }
        
    }
}
