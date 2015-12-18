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
using Amazon.Redshift;
using Amazon.Redshift.Model;

namespace Amazon.PowerShell.Cmdlets.RS
{
    /// <summary>
    /// Adds one or more tags to a specified resource. 
    /// 
    ///  
    /// <para>
    ///  A resource can have up to 10 tags. If you try to create more than 10 tags for a resource,
    /// you will receive an error and the attempt will fail. 
    /// </para><para>
    ///  If you specify a key that already exists for the resource, the value for that key
    /// will be updated with the new value. 
    /// </para>
    /// </summary>
    [Cmdlet("New", "RSTags", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Invokes the CreateTags operation against Amazon Redshift.", Operation = new[] {"CreateTags"})]
    [AWSCmdletOutput("None",
        "This cmdlet does not generate any output. " +
        "The service response (type Amazon.Redshift.Model.CreateTagsResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class NewRSTagsCmdlet : AmazonRedshiftClientCmdlet, IExecutor
    {
        
        #region Parameter ResourceName
        /// <summary>
        /// <para>
        /// <para> The Amazon Resource Name (ARN) to which you want to add the tag or tags. For example,
        /// <code>arn:aws:redshift:us-east-1:123456789:cluster:t1</code>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ResourceName { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para> One or more name/value pairs to add as tags to the specified resource. Each tag name
        /// is passed in with the parameter <code>Key</code> and the corresponding value is passed
        /// in with the parameter <code>Value</code>. The <code>Key</code> and <code>Value</code>
        /// parameters are separated by a comma (,). Separate multiple tags with a space. For
        /// example, <code>--tags "Key"="owner","Value"="admin" "Key"="environment","Value"="test"
        /// "Key"="version","Value"="1.0"</code>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Tags")]
        public Amazon.Redshift.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("ResourceName", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-RSTags (CreateTags)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.ResourceName = this.ResourceName;
            if (this.Tag != null)
            {
                context.Tags = new List<Amazon.Redshift.Model.Tag>(this.Tag);
            }
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.Redshift.Model.CreateTagsRequest();
            
            if (cmdletContext.ResourceName != null)
            {
                request.ResourceName = cmdletContext.ResourceName;
            }
            if (cmdletContext.Tags != null)
            {
                request.Tags = cmdletContext.Tags;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.CreateTags(request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = null;
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
            public System.String ResourceName { get; set; }
            public List<Amazon.Redshift.Model.Tag> Tags { get; set; }
        }
        
    }
}
