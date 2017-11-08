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
    /// Creates a new thing type.
    /// </summary>
    [Cmdlet("New", "IOTThingType", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.IoT.Model.CreateThingTypeResponse")]
    [AWSCmdlet("Calls the AWS IoT CreateThingType API operation.", Operation = new[] {"CreateThingType"})]
    [AWSCmdletOutput("Amazon.IoT.Model.CreateThingTypeResponse",
        "This cmdlet returns a Amazon.IoT.Model.CreateThingTypeResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewIOTThingTypeCmdlet : AmazonIoTClientCmdlet, IExecutor
    {
        
        #region Parameter ThingTypeProperties_SearchableAttribute
        /// <summary>
        /// <para>
        /// <para>A list of searchable thing attribute names.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("ThingTypeProperties_SearchableAttributes")]
        public System.String[] ThingTypeProperties_SearchableAttribute { get; set; }
        #endregion
        
        #region Parameter ThingTypeProperties_ThingTypeDescription
        /// <summary>
        /// <para>
        /// <para>The description of the thing type.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ThingTypeProperties_ThingTypeDescription { get; set; }
        #endregion
        
        #region Parameter ThingTypeName
        /// <summary>
        /// <para>
        /// <para>The name of the thing type.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String ThingTypeName { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("ThingTypeName", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-IOTThingType (CreateThingType)"))
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
            
            context.ThingTypeName = this.ThingTypeName;
            if (this.ThingTypeProperties_SearchableAttribute != null)
            {
                context.ThingTypeProperties_SearchableAttributes = new List<System.String>(this.ThingTypeProperties_SearchableAttribute);
            }
            context.ThingTypeProperties_ThingTypeDescription = this.ThingTypeProperties_ThingTypeDescription;
            
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
            var request = new Amazon.IoT.Model.CreateThingTypeRequest();
            
            if (cmdletContext.ThingTypeName != null)
            {
                request.ThingTypeName = cmdletContext.ThingTypeName;
            }
            
             // populate ThingTypeProperties
            bool requestThingTypePropertiesIsNull = true;
            request.ThingTypeProperties = new Amazon.IoT.Model.ThingTypeProperties();
            List<System.String> requestThingTypeProperties_thingTypeProperties_SearchableAttribute = null;
            if (cmdletContext.ThingTypeProperties_SearchableAttributes != null)
            {
                requestThingTypeProperties_thingTypeProperties_SearchableAttribute = cmdletContext.ThingTypeProperties_SearchableAttributes;
            }
            if (requestThingTypeProperties_thingTypeProperties_SearchableAttribute != null)
            {
                request.ThingTypeProperties.SearchableAttributes = requestThingTypeProperties_thingTypeProperties_SearchableAttribute;
                requestThingTypePropertiesIsNull = false;
            }
            System.String requestThingTypeProperties_thingTypeProperties_ThingTypeDescription = null;
            if (cmdletContext.ThingTypeProperties_ThingTypeDescription != null)
            {
                requestThingTypeProperties_thingTypeProperties_ThingTypeDescription = cmdletContext.ThingTypeProperties_ThingTypeDescription;
            }
            if (requestThingTypeProperties_thingTypeProperties_ThingTypeDescription != null)
            {
                request.ThingTypeProperties.ThingTypeDescription = requestThingTypeProperties_thingTypeProperties_ThingTypeDescription;
                requestThingTypePropertiesIsNull = false;
            }
             // determine if request.ThingTypeProperties should be set to null
            if (requestThingTypePropertiesIsNull)
            {
                request.ThingTypeProperties = null;
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
        
        private Amazon.IoT.Model.CreateThingTypeResponse CallAWSServiceOperation(IAmazonIoT client, Amazon.IoT.Model.CreateThingTypeRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS IoT", "CreateThingType");
            try
            {
                #if DESKTOP
                return client.CreateThingType(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.CreateThingTypeAsync(request);
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
            public System.String ThingTypeName { get; set; }
            public List<System.String> ThingTypeProperties_SearchableAttributes { get; set; }
            public System.String ThingTypeProperties_ThingTypeDescription { get; set; }
        }
        
    }
}
