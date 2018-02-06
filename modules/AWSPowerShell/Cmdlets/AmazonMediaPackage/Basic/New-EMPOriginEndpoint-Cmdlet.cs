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
using Amazon.MediaPackage;
using Amazon.MediaPackage.Model;

namespace Amazon.PowerShell.Cmdlets.EMP
{
    /// <summary>
    /// Creates a new OriginEndpoint record.
    /// </summary>
    [Cmdlet("New", "EMPOriginEndpoint", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.MediaPackage.Model.CreateOriginEndpointResponse")]
    [AWSCmdlet("Calls the AWS Elemental MediaPackage CreateOriginEndpoint API operation.", Operation = new[] {"CreateOriginEndpoint"})]
    [AWSCmdletOutput("Amazon.MediaPackage.Model.CreateOriginEndpointResponse",
        "This cmdlet returns a Amazon.MediaPackage.Model.CreateOriginEndpointResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewEMPOriginEndpointCmdlet : AmazonMediaPackageClientCmdlet, IExecutor
    {
        
        #region Parameter ChannelId
        /// <summary>
        /// <para>
        /// The ID of the Channel that the OriginEndpoint
        /// will be associated with.This cannot be changed after the OriginEndpoint is created.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ChannelId { get; set; }
        #endregion
        
        #region Parameter DashPackage
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Amazon.MediaPackage.Model.DashPackage DashPackage { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// A short text description of the OriginEndpoint.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter HlsPackage
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Amazon.MediaPackage.Model.HlsPackage HlsPackage { get; set; }
        #endregion
        
        #region Parameter Id
        /// <summary>
        /// <para>
        /// The ID of the OriginEndpoint.  The ID must be unique
        /// within the regionand it cannot be changed after the OriginEndpoint is created.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String Id { get; set; }
        #endregion
        
        #region Parameter ManifestName
        /// <summary>
        /// <para>
        /// A short string that will be used as the filename
        /// of the OriginEndpoint URL (defaults to "index").
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ManifestName { get; set; }
        #endregion
        
        #region Parameter MssPackage
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Amazon.MediaPackage.Model.MssPackage MssPackage { get; set; }
        #endregion
        
        #region Parameter StartoverWindowSecond
        /// <summary>
        /// <para>
        /// Maximum duration (seconds) of content
        /// to retain for startover playback.If not specified, startover playback will be disabled
        /// for the OriginEndpoint.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("StartoverWindowSeconds")]
        public System.Int32 StartoverWindowSecond { get; set; }
        #endregion
        
        #region Parameter TimeDelaySecond
        /// <summary>
        /// <para>
        /// Amount of delay (seconds) to enforce
        /// on the playback of live content.If not specified, there will be no time delay in effect
        /// for the OriginEndpoint.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("TimeDelaySeconds")]
        public System.Int32 TimeDelaySecond { get; set; }
        #endregion
        
        #region Parameter Whitelist
        /// <summary>
        /// <para>
        /// A list of source IP CIDR blocks that will be
        /// allowed to access the OriginEndpoint.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String[] Whitelist { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("Id", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-EMPOriginEndpoint (CreateOriginEndpoint)"))
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
            
            context.ChannelId = this.ChannelId;
            context.DashPackage = this.DashPackage;
            context.Description = this.Description;
            context.HlsPackage = this.HlsPackage;
            context.Id = this.Id;
            context.ManifestName = this.ManifestName;
            context.MssPackage = this.MssPackage;
            if (ParameterWasBound("StartoverWindowSecond"))
                context.StartoverWindowSeconds = this.StartoverWindowSecond;
            if (ParameterWasBound("TimeDelaySecond"))
                context.TimeDelaySeconds = this.TimeDelaySecond;
            if (this.Whitelist != null)
            {
                context.Whitelist = new List<System.String>(this.Whitelist);
            }
            
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
            var request = new Amazon.MediaPackage.Model.CreateOriginEndpointRequest();
            
            if (cmdletContext.ChannelId != null)
            {
                request.ChannelId = cmdletContext.ChannelId;
            }
            if (cmdletContext.DashPackage != null)
            {
                request.DashPackage = cmdletContext.DashPackage;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.HlsPackage != null)
            {
                request.HlsPackage = cmdletContext.HlsPackage;
            }
            if (cmdletContext.Id != null)
            {
                request.Id = cmdletContext.Id;
            }
            if (cmdletContext.ManifestName != null)
            {
                request.ManifestName = cmdletContext.ManifestName;
            }
            if (cmdletContext.MssPackage != null)
            {
                request.MssPackage = cmdletContext.MssPackage;
            }
            if (cmdletContext.StartoverWindowSeconds != null)
            {
                request.StartoverWindowSeconds = cmdletContext.StartoverWindowSeconds.Value;
            }
            if (cmdletContext.TimeDelaySeconds != null)
            {
                request.TimeDelaySeconds = cmdletContext.TimeDelaySeconds.Value;
            }
            if (cmdletContext.Whitelist != null)
            {
                request.Whitelist = cmdletContext.Whitelist;
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
        
        private Amazon.MediaPackage.Model.CreateOriginEndpointResponse CallAWSServiceOperation(IAmazonMediaPackage client, Amazon.MediaPackage.Model.CreateOriginEndpointRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Elemental MediaPackage", "CreateOriginEndpoint");
            try
            {
                #if DESKTOP
                return client.CreateOriginEndpoint(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.CreateOriginEndpointAsync(request);
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
            public System.String ChannelId { get; set; }
            public Amazon.MediaPackage.Model.DashPackage DashPackage { get; set; }
            public System.String Description { get; set; }
            public Amazon.MediaPackage.Model.HlsPackage HlsPackage { get; set; }
            public System.String Id { get; set; }
            public System.String ManifestName { get; set; }
            public Amazon.MediaPackage.Model.MssPackage MssPackage { get; set; }
            public System.Int32? StartoverWindowSeconds { get; set; }
            public System.Int32? TimeDelaySeconds { get; set; }
            public List<System.String> Whitelist { get; set; }
        }
        
    }
}
