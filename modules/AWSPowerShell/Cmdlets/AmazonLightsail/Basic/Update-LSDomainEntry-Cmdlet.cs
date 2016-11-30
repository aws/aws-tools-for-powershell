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
using Amazon.Lightsail;
using Amazon.Lightsail.Model;

namespace Amazon.PowerShell.Cmdlets.LS
{
    /// <summary>
    /// Updates a domain recordset after it is created.
    /// </summary>
    [Cmdlet("Update", "LSDomainEntry", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Lightsail.Model.Operation")]
    [AWSCmdlet("Invokes the UpdateDomainEntry operation against Amazon Lightsail.", Operation = new[] {"UpdateDomainEntry"})]
    [AWSCmdletOutput("Amazon.Lightsail.Model.Operation",
        "This cmdlet returns a collection of Operation objects.",
        "The service call response (type Amazon.Lightsail.Model.UpdateDomainEntryResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateLSDomainEntryCmdlet : AmazonLightsailClientCmdlet, IExecutor
    {
        
        #region Parameter DomainName
        /// <summary>
        /// <para>
        /// <para>The name of the domain recordset to update.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String DomainName { get; set; }
        #endregion
        
        #region Parameter DomainEntry_Id
        /// <summary>
        /// <para>
        /// <para>The ID of the domain recordset entry.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String DomainEntry_Id { get; set; }
        #endregion
        
        #region Parameter DomainEntry_Name
        /// <summary>
        /// <para>
        /// <para>The name of the domain.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String DomainEntry_Name { get; set; }
        #endregion
        
        #region Parameter DomainEntry_Option
        /// <summary>
        /// <para>
        /// <para>The options for the domain entry.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("DomainEntry_Options")]
        public System.Collections.Hashtable DomainEntry_Option { get; set; }
        #endregion
        
        #region Parameter DomainEntry_Target
        /// <summary>
        /// <para>
        /// <para>The target AWS name server (e.g., <code>ns-111.awsdns-22.com.</code>).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String DomainEntry_Target { get; set; }
        #endregion
        
        #region Parameter DomainEntry_Type
        /// <summary>
        /// <para>
        /// <para>The type of domain entry (e.g., <code>SOA</code> or <code>NS</code>).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String DomainEntry_Type { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("DomainName", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-LSDomainEntry (UpdateDomainEntry)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            context.DomainEntry_Id = this.DomainEntry_Id;
            context.DomainEntry_Name = this.DomainEntry_Name;
            if (this.DomainEntry_Option != null)
            {
                context.DomainEntry_Options = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.DomainEntry_Option.Keys)
                {
                    context.DomainEntry_Options.Add((String)hashKey, (String)(this.DomainEntry_Option[hashKey]));
                }
            }
            context.DomainEntry_Target = this.DomainEntry_Target;
            context.DomainEntry_Type = this.DomainEntry_Type;
            context.DomainName = this.DomainName;
            
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
            var request = new Amazon.Lightsail.Model.UpdateDomainEntryRequest();
            
            
             // populate DomainEntry
            bool requestDomainEntryIsNull = true;
            request.DomainEntry = new Amazon.Lightsail.Model.DomainEntry();
            System.String requestDomainEntry_domainEntry_Id = null;
            if (cmdletContext.DomainEntry_Id != null)
            {
                requestDomainEntry_domainEntry_Id = cmdletContext.DomainEntry_Id;
            }
            if (requestDomainEntry_domainEntry_Id != null)
            {
                request.DomainEntry.Id = requestDomainEntry_domainEntry_Id;
                requestDomainEntryIsNull = false;
            }
            System.String requestDomainEntry_domainEntry_Name = null;
            if (cmdletContext.DomainEntry_Name != null)
            {
                requestDomainEntry_domainEntry_Name = cmdletContext.DomainEntry_Name;
            }
            if (requestDomainEntry_domainEntry_Name != null)
            {
                request.DomainEntry.Name = requestDomainEntry_domainEntry_Name;
                requestDomainEntryIsNull = false;
            }
            Dictionary<System.String, System.String> requestDomainEntry_domainEntry_Option = null;
            if (cmdletContext.DomainEntry_Options != null)
            {
                requestDomainEntry_domainEntry_Option = cmdletContext.DomainEntry_Options;
            }
            if (requestDomainEntry_domainEntry_Option != null)
            {
                request.DomainEntry.Options = requestDomainEntry_domainEntry_Option;
                requestDomainEntryIsNull = false;
            }
            System.String requestDomainEntry_domainEntry_Target = null;
            if (cmdletContext.DomainEntry_Target != null)
            {
                requestDomainEntry_domainEntry_Target = cmdletContext.DomainEntry_Target;
            }
            if (requestDomainEntry_domainEntry_Target != null)
            {
                request.DomainEntry.Target = requestDomainEntry_domainEntry_Target;
                requestDomainEntryIsNull = false;
            }
            System.String requestDomainEntry_domainEntry_Type = null;
            if (cmdletContext.DomainEntry_Type != null)
            {
                requestDomainEntry_domainEntry_Type = cmdletContext.DomainEntry_Type;
            }
            if (requestDomainEntry_domainEntry_Type != null)
            {
                request.DomainEntry.Type = requestDomainEntry_domainEntry_Type;
                requestDomainEntryIsNull = false;
            }
             // determine if request.DomainEntry should be set to null
            if (requestDomainEntryIsNull)
            {
                request.DomainEntry = null;
            }
            if (cmdletContext.DomainName != null)
            {
                request.DomainName = cmdletContext.DomainName;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.Operations;
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
        
        private static Amazon.Lightsail.Model.UpdateDomainEntryResponse CallAWSServiceOperation(IAmazonLightsail client, Amazon.Lightsail.Model.UpdateDomainEntryRequest request)
        {
            #if DESKTOP
            return client.UpdateDomainEntry(request);
            #elif CORECLR
            // todo: handle AggregateException and extract true service exception for rethrow
            var task = client.UpdateDomainEntryAsync(request);
            return task.Result;
            #else
                    #error "Unknown build edition"
            #endif
        }
        
        #endregion
        
        internal class CmdletContext : ExecutorContext
        {
            public System.String DomainEntry_Id { get; set; }
            public System.String DomainEntry_Name { get; set; }
            public Dictionary<System.String, System.String> DomainEntry_Options { get; set; }
            public System.String DomainEntry_Target { get; set; }
            public System.String DomainEntry_Type { get; set; }
            public System.String DomainName { get; set; }
        }
        
    }
}
